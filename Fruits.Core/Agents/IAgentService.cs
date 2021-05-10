using System.Threading;
using System.Threading.Tasks;
using Fruits.Core.Commons;

namespace Fruits.Core.Agents
{
    public interface IAgentService
    {
        Task<OperationResult> RegisterAgentAsync(AgentModel agent, CancellationToken token = default);
        Task<OperationResult> DeleteAgentAsync(long agentId, CancellationToken token = default);
    }
}
