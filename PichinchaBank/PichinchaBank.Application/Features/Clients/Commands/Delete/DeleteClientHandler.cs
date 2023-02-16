using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;

namespace PichinchaBank.Application.Features.Clients.Commands.Delete
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<DeleteClientHandler> logger;

        public DeleteClientHandler(IUnitOfWork uow, ILogger<DeleteClientHandler> logger)
        {
            this.uow = uow;
            this.logger = logger;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var clientToDelete = await uow.CustomClientRepository.GetClientByIdentification(request.Identification);
            uow.CustomClientRepository.DeleteEntity(clientToDelete);
            await uow.Complete();
            logger.LogInformation($"The ID {request.Identification} was deleted successfully");
            return Unit.Value;
        }
    }
}
