using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Clients.Commands.Delete;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Accounts.Commands.Delete
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<DeleteAccountHandler> logger;

        public DeleteAccountHandler(IUnitOfWork uow, IMapper mapper, ILogger<DeleteAccountHandler> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelete = await uow.CustomAccountRepository.GetAccountByAccountNumber(request.AccountNumber);
            if (accountToDelete == null)
            {
                logger.LogError($"{request.AccountNumber} NOT found on database");
                throw new NotFoundException(nameof(Client), request.AccountNumber);
            }
            uow.CustomAccountRepository.DeleteEntity(accountToDelete);
            await uow.Complete();
            logger.LogInformation($"The ID {request.AccountNumber} was deleted successfully");
            return Unit.Value;
        }
    }
}
