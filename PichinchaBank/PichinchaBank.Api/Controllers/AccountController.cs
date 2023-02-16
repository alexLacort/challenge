using MediatR;
using Microsoft.AspNetCore.Mvc;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Features.Accounts.Commands.Delete;
using PichinchaBank.Application.Features.Accounts.Commands.Update;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Models;
using System.Net;

namespace PichinchaBank.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IAccountManager accountManager;

        public AccountController(IMediator mediator, IAccountManager accountManager)
        {
            this.mediator = mediator;
            this.accountManager = accountManager;
        }

        [HttpPost(Name = "Account")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Account([FromBody] AccountRequest request)
        {
            var result = await accountManager.CreateAccount(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("AllAccounts")]
        [ProducesResponseType(typeof(IEnumerable<AccountVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AccountVm>>> AllAccounts()
        {
            var query = new GetAllAccountQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{accountNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Account(int accountNumber)
        {
            var command = new DeleteAccountCommand { AccountNumber = accountNumber };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Account([FromBody] UpdateAccountCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
