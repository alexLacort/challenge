using FluentValidation;

namespace PichinchaBank.Application.Features.BankingTransactions.Commands.Create
{
    public class CreateBankTransactionValidator : AbstractValidator<CreateBankTransactionCommand>
    {
        public CreateBankTransactionValidator()
        {
            RuleFor(r => r.AccountNumber)
                .NotEmpty().WithMessage("{AccountNumber} can not be empty")
                .NotNull().WithMessage("{AccountNumber} can not be null")
                .GreaterThan(0).WithMessage("{AccountNumber} can not be negative or 0");

            RuleFor(r => r.TransactionType).IsInEnum();

            RuleFor(r => r.AccountId)
                .NotEmpty().WithMessage("{AccountId} can not be empty")
                .NotNull().WithMessage("{AccountId} can not be null");

            RuleFor(r => r.Amount)
                .NotEmpty().WithMessage("{Amount} can not be empty")
                .NotNull().WithMessage("{Amount} can not be null")
                .GreaterThan(0).WithMessage("{Amount} can not be negative");
        }
    }
}
