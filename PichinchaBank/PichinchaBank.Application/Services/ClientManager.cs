using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.Clients.Commands.Create;
using PichinchaBank.Application.Features.Clients.Commands.Delete;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Services
{
    public class ClientManager : IClientManager
    {
        private IMediator mediator;

        public ClientManager(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<int> CreateClient(CreateClientCommand request)
        {
            var clientExist = await mediator.Send(new GetClientByIdentificationQuery(request.Identification));
            if (clientExist != null)
            {
                throw new EntityAlreadyExistException("The client have already exist on database");
            }
            return await mediator.Send(request);
        }

        public async Task DeleteClient(DeleteClientCommand request)
        {
            var clientToDelete = await mediator.Send(new GetClientByIdentificationQuery(request.Identification));
            if (clientToDelete == null)
            {
                throw new NotFoundException(nameof(Client), request.Identification);
            }

            var clientHaveAccounts = await mediator.Send(new GetAccountsByClientQuery() { ClientId = clientToDelete.Id });
            if (clientHaveAccounts.Any())
            {
                throw new EntityAlreadyExistException("The client have accounts associated, it can not be deleted");
            }
            await mediator.Send(request);
        }
    }
}
