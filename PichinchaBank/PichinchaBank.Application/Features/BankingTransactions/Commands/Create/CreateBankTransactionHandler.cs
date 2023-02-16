using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.BankingTransactions.Commands.Create
{
    public class CreateBankTransactionHandler : IRequestHandler<CreateBankTransactionCommand>
    {
        private readonly ILogger<CreateBankTransactionHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public CreateBankTransactionHandler(ILogger<CreateBankTransactionHandler> logger, IMapper mapper, IUnitOfWork uow)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<Unit> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
        {
            var bankingTransactionEntity = mapper.Map<BankingTransaction>(request);
            uow.Repository<BankingTransaction>().AddEntity(bankingTransactionEntity);

            var result = await uow.Complete();
            if (result <= 0)
            {
                logger.LogError($"We can not save the Transaction on Database");
                throw new Exception("We can not save the Transaction on Database");
            }
            return Unit.Value;
        }
    }
}
