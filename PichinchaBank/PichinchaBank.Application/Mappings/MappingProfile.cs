using AutoMapper;
using PichinchaBank.Application.Features.Accounts.Commands.Create;
using PichinchaBank.Application.Features.Accounts.Commands.Update;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.BankingTransactions.Commands.Create;
using PichinchaBank.Application.Features.Clients.Commands.Create;
using PichinchaBank.Application.Features.Clients.Commands.Update;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Application.Models;
using PichinchaBank.Domain;

namespace PichinchaBank.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap< Origen, Destino>            
            CreateMap<CreateClientCommand, Client>().ReverseMap();
            CreateMap<UpdateClientCommand, Client>().ReverseMap();
            CreateMap<Client, ClientVm>().ReverseMap();
            CreateMap<CreateAccountCommand, Account>().ReverseMap();
            CreateMap<UpdateAccountCommand, Account>().ReverseMap();
            CreateMap<AccountVm, UpdateAccountCommand>().ReverseMap();
            CreateMap<Account, AccountVm>().ReverseMap();
            CreateMap<CreateBankTransactionCommand, BankingTransaction>().ReverseMap();
            CreateMap<BankingTransactionRequest, CreateBankTransactionCommand>().ReverseMap();
        }
    }
}
