using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using PichinchaBank.Domain;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Application.Features.Clients.Commands.Create;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.Clients.Commands.Delete;
using PichinchaBank.Application.Features.Clients.Commands.Update;
using PichinchaBank.Application.Contracts.Services;

namespace PichinchaBank.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IClientManager clientManager;

        public ClientController(IMediator mediator, IClientManager clientManager)
        {
            this.mediator = mediator;
            this.clientManager = clientManager;
        }

        [HttpPost(Name = "Client")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Account([FromBody] CreateClientCommand command)
        {
            var result = await clientManager.CreateClient(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("ClientByIdentification/{clientIdentification}")]
        [ProducesResponseType(typeof(IEnumerable<Client>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Client>>> ClientByIdentification(string clientIdentification)
        {
            var query = new GetClientByIdentificationQuery(clientIdentification);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("AllClients")]
        [ProducesResponseType(typeof(IEnumerable<ClientVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientVm>>> AllClients()
        {
            var query = new GetAllClientsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{identification}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Client(string identification)
        {
            await clientManager.DeleteClient(new DeleteClientCommand { Identification = identification });
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Client([FromBody] UpdateClientCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
