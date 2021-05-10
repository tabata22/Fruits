using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fruits.Data.Agents
{
    public class AgentRepository : BaseRepository<Agent>, IAgentRepository
    {
        public AgentRepository(FruitsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task DeleteAgent(long agentId, CancellationToken token = default)
        {
            var agent = await GetAsync(x=> x.Id == agentId && x.DeletedAt == null, token);
            if (agent == null)
                throw new Exception("agent not found");

            agent.DeletedAt = DateTime.Now;
        }
    }
}
