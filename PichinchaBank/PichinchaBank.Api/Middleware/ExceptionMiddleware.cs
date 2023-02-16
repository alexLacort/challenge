using Newtonsoft.Json;
using PichinchaBank.Application.Exceptions;
using System.Net;
using NotFoundException = PichinchaBank.Application.Exceptions.NotFoundException;

namespace PichinchaBank.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate nextPipeline;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate nextPipeline, ILogger<ExceptionMiddleware> logger)
        {
            this.nextPipeline = nextPipeline;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await nextPipeline(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCodeDefault = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;
                switch (ex)
                {
                    case NotFoundException nfe:
                        statusCodeDefault = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException ve:
                        statusCodeDefault = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(ve.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCodeDefault, ex.Message, validationJson));
                        break;
                    case BadRequestException bre:
                        statusCodeDefault = (int)HttpStatusCode.BadRequest;
                        break;
                    default: break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCodeDefault, ex.Message, ex.StackTrace));
                }

                context.Response.StatusCode = statusCodeDefault;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
