using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Clients.Commands.Delete;
using PichinchaBank.Application.Features.Clients.Commands.Update;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Accounts.Commands.Update
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateAccountHandler> logger;

        public UpdateAccountHandler(IUnitOfWork uow, IMapper mapper, ILogger<UpdateAccountHandler> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToUpdate = await uow.CustomAccountRepository.GetAccountByAccountNumber(request.AccountNumber);
            if (accountToUpdate == null)
            {
                logger.LogError($"{request.AccountNumber} NOT found on database");
                throw new NotFoundException(nameof(Client), request.AccountNumber);
            }
            mapper.Map(request, accountToUpdate, typeof(UpdateAccountCommand), typeof(Account));
            uow.CustomAccountRepository.UpdateEntity(accountToUpdate);
            await uow.Complete();
            logger.LogInformation($"The ID {request.AccountNumber} was updated successfully");
            return Unit.Value;
        }
    }
}
