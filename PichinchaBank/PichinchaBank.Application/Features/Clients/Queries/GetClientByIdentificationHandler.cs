
using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Persistence;

namespace PichinchaBank.Application.Features.Clients.Queries
{
    public class GetClientByIdentificationHandler : IRequestHandler<GetClientByIdentificationQuery, ClientVm>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetClientByIdentificationHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ClientVm> Handle(GetClientByIdentificationQuery request, CancellationToken cancellationToken)
        {
            var client = await uow.CustomClientRepository.GetClientByIdentification(request.ClientIdentification);
            var result = mapper.Map<ClientVm>(client);
            return result;
        }
    }
}
