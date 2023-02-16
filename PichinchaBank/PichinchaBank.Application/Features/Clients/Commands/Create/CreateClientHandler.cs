using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Clients.Commands.Create
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly ILogger<CreateClientHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public CreateClientHandler(ILogger<CreateClientHandler> logger, IMapper mapper, IUnitOfWork uow)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = mapper.Map<Client>(request);
            uow.Repository<Client>().AddEntity(clientEntity);
            var result = await uow.Complete();
            if (result <= 0)
            {
                logger.LogError($"We can not save the Client on Database");
                throw new Exception("We can not save the client on Database");
            }
            return clientEntity.Id;
        }
    }
}
