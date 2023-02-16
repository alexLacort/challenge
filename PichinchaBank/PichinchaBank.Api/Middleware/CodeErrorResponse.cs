namespace PichinchaBank.Api.Middleware
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request sended have errors",
                404 => "Not found element",
                500 => "Ups! we have an error!",
                _ => string.Empty
            };
        }
    }
}
