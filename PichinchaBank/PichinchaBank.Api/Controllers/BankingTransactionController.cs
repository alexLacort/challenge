using MediatR;
using Microsoft.AspNetCore.Mvc;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Models;

namespace PichinchaBank.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BankingTransactionController : ControllerBase
    {
        private readonly IBankTransactionManager bankTransactionManager;

        public BankingTransactionController(IBankTransactionManager bankTransactionManager)
        {
            this.bankTransactionManager = bankTransactionManager;
        }

        [HttpPost(Name = "BankTransaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> BankTransaction([FromBody] BankingTransactionRequest request)
        {
            await bankTransactionManager.CreateBankTransaction(request);
            return NoContent();
        }
    }
}
