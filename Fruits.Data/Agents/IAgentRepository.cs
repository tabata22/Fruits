using System.Threading;
using System.Threading.Tasks;

namespace Fruits.Data.Agents
{
    public interface IAgentRepository : IBaseRepository<Agent>
    {
        Task DeleteAgent(long agentId, CancellationToken token = default);
    }
}
