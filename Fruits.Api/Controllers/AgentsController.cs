using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Fruits.Core.Agents;
using Fruits.Core.Commons;

namespace Fruits.Api.Controllers
{
    [Route("v1/Agents")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentsController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(OperationResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<OperationResult> RegisterAsync([FromBody, Required] AgentModel agent, CancellationToken token = default) 
            => _agentService.RegisterAgentAsync(agent, token);

        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(OperationResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<OperationResult> DeleteAsync([FromQuery, Required] long agentId, CancellationToken token = default)
            => _agentService.DeleteAgentAsync(agentId, token);
    }
}
