using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Features.Accounts.Queries;

namespace PichinchaBank.Application.Features.Clients.Queries
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientVm>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllClientsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClientVm>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await uow.CustomClientRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ClientVm>>(clients);
        }
    }
}
