using MediatR;
using Microsoft.AspNetCore.Mvc;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Features.Accounts.Queries;
using PichinchaBank.Application.Features.BankingTransactions.Queries;
using PichinchaBank.Application.Features.Clients.Queries;
using PichinchaBank.Application.Models;
using PichinchaBank.Domain;
using System.Net;

namespace PichinchaBank.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IBankTransactionManager bankTransactionManager;

        public ReportController(IBankTransactionManager bankTransactionManager)
        {
            this.bankTransactionManager = bankTransactionManager;
        }

        [HttpGet("{clientIdentification}/{from:DateTime}/{to:DateTime}")]
        [ProducesResponseType(typeof(IEnumerable<ReportResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReportResponse>>> TransactionReport(string clientIdentification, DateTime from, DateTime to)
        {
            var result = await bankTransactionManager.TransactionReport(new GetReportTransactionsQuery { Identification = clientIdentification, InitialDate = from, EndDate = to });
            return Ok(result);
        }
    }
}
