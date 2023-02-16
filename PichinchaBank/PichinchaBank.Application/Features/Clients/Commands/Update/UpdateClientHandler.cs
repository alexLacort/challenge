using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Exceptions;
using PichinchaBank.Application.Features.Clients.Commands.Delete;
using PichinchaBank.Domain;
using System.IO;

namespace PichinchaBank.Application.Features.Clients.Commands.Update
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateClientHandler> logger;

        public UpdateClientHandler(IUnitOfWork uow, IMapper mapper, ILogger<UpdateClientHandler> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await uow.CustomClientRepository.GetClientByIdentification(request.Identification);
            if (clientToUpdate == null)
            {
                logger.LogError($"{request.Identification} NOT found on database");
                throw new NotFoundException(nameof(Client), request.Identification);
            }
            mapper.Map(request, clientToUpdate, typeof(UpdateClientCommand), typeof(Client));
            uow.CustomClientRepository.UpdateEntity(clientToUpdate);
            await uow.Complete();
            logger.LogInformation($"The ID {request.Identification} was updated successfully");
            return Unit.Value;
        }
    }
}
