using AutoMapper;
using MediatR;
using PichinchaBank.Application.Contracts.Persistence;

namespace PichinchaBank.Application.Features.Accounts.Queries
{
    public class GetAccountByIdNumberHandler : IRequestHandler<GetAccountByIdNumberQuery, AccountVm>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAccountByIdNumberHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<AccountVm> Handle(GetAccountByIdNumberQuery request, CancellationToken cancellationToken)
        {
            var client = await uow.CustomAccountRepository.GetAccountByAccountNumber(request.AccountNumber);
            var result = mapper.Map<AccountVm>(client);
            return result;
        }
    }
}
