using FluentValidation;

namespace PichinchaBank.Application.Features.BankingTransactions.Queries
{
    public class GetReportTransactionsValidator : AbstractValidator<GetReportTransactionsQuery>
    {
        public GetReportTransactionsValidator()
        {
            RuleFor(r=>r.Identification)
                .NotEmpty().WithMessage("{Identification} can not be empty")
                .NotNull().WithMessage("{Identification} can not be null");

            RuleFor(r => r.InitialDate)
                .NotEmpty().WithMessage("{InitialDate} can not be empty")
                .NotNull().WithMessage("{InitialDate} can not be null")
                .Must(BeAValidDate).WithMessage("{InitialDate} Start date is requeired");

            RuleFor(r => r.EndDate)
                .NotEmpty().WithMessage("{EndDate} can not be empty")
                .NotNull().WithMessage("{EndDate} can not be null")
                .Must(BeAValidDate).WithMessage("{EndDate} Start date is requeired");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
