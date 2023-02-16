using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAccountsByClientHandler : IRequestHandler<GetAccountsByClientQuery, IEnumerable<AccountVm>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAccountsByClientHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AccountVm>> Handle(GetAccountsByClientQuery request, CancellationToken cancellationToken)
        {
            var listAccounts = await uow.CustomAccountRepository.GetAccountByClient(request.ClientId);
            return mapper.Map<IEnumerable<AccountVm>>(listAccounts);
        }
    }
}
