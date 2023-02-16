using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Accounts.Commands.Create
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly ILogger<CreateAccountHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public CreateAccountHandler(ILogger<CreateAccountHandler> logger, IMapper mapper, IUnitOfWork uow)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = mapper.Map<Account>(request);
            uow.Repository<Account>().AddEntity(accountEntity);
            var result = await uow.Complete();
            if (result <= 0)
            {
                logger.LogError($"We can not save the Account on Database");
                throw new Exception("We can not save the Account on Database");
            }
            return accountEntity.Id;
        }
    }
}
