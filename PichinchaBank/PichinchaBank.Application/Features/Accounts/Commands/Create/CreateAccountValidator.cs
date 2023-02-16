using FluentValidation;

namespace PichinchaBank.Application.Features.Accounts.Commands.Create
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(r => r.AccountNumber)
                .NotEmpty().WithMessage("{AccountNumber} can not be empty")
                .NotNull().WithMessage("{AccountNumber} can not be null");
            RuleFor(r => r.AccountType).IsInEnum();
        }
    }
}
