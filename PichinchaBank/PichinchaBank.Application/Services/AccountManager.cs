using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Accounts.Commands.Create;
using PichinchaBank.Application.Features.Accounts.Commands.Delete;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Application.Models;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Services
{
    public class AccountManager : IAccountManager
    {
        private IMediator mediator;

        public AccountManager(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<int> CreateAccount(AccountRequest request)
        {
            var requestClientByIdentification = new GetClientByIdentificationQuery(request.Identification);
            var clientExist = await mediator.Send(requestClientByIdentification);

            if (clientExist == null)
            {
                throw new NotFoundException($"The client with identification: {request.Identification} doesn't exist");
            }
            var result = await mediator.Send(new CreateAccountCommand
            {
                AccountNumber = request.AccountNumber,
                AccountType = request.AccountType,
                InitialBalance = request.InitialBalance,
                Identification = request.Identification,
                ClientId = clientExist.Id
            });

            return result;
        }

    }
}
