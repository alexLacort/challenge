using FluentValidation;
using PichinchaBank.Application.Features.Accounts.Commands.Create;

namespace PichinchaBank.Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountValidator()
        {
            RuleFor(r => r.AccountNumber)
                .NotEmpty().WithMessage("{AccountNumber} can not be empty")
                .NotNull().WithMessage("{AccountNumber} can not be null");
            RuleFor(r => r.AccountType).IsInEnum();
            RuleFor(r => r.State).IsInEnum();
        }
    }
}
