using PichinchaBank.Application.Features.Accounts.Commands.Delete;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Application.Contracts.Services
{
    public interface IAccountManager
    {
        Task<int> CreateAccount(AccountRequest request);
    }
}
