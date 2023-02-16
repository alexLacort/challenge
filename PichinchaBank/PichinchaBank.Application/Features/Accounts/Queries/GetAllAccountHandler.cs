using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Persistence;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAllAccountHandler : IRequestHandler<GetAllAccountQuery, IEnumerable<AccountVm>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllAccountHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AccountVm>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await uow.CustomAccountRepository.GetAllAsync();
            return mapper.Map<IEnumerable<AccountVm>>(accounts);
        }
    }
}
