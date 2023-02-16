using FluentValidation;

namespace PichinchaBank.Application.Features.Clients.Commands.Update
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(r => r.Identification)
                .NotEmpty().WithMessage("{Identification} can not be empty")
                .NotNull().WithMessage("{Identification} can not be null");

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{Name} can not be empty")
                .NotNull().WithMessage("{Name} can not be null");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("{Password} can not be empty")
                .NotNull().WithMessage("{Password} can not be null");

            RuleFor(r => r.State).IsInEnum();
        }
    }
}
