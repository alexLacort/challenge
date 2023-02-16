using FluentValidation;
using MediatR;

namespace PichinchaBank.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Capturar todas las validaciones definidas "Validator" para los Request
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationsResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationsResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                //Validar que existan erroes en la lista
                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }

}
