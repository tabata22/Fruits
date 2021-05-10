using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Fruits.Core.Commons;
using Fruits.Core.Statements;

namespace Fruits.Api.Controllers
{
    [Route("v1/Statements")]
    [ApiController]
    public class StatementsController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementsController(IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(OperationResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<OperationResult> CreateAsync([FromBody, Required] StatementModel statement, CancellationToken token = default) 
            => _statementService.CreateStatementAsync(statement, token);

        [HttpPost("Approve")]
        [ProducesResponseType(typeof(OperationResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<OperationResult> ApproveAsync([FromQuery, Required] long statementId, CancellationToken token = default)
            => _statementService.ApproveStatementAsync(statementId, token);
    }
}
