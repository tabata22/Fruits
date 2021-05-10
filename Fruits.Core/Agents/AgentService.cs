using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Fruits.Core.Commons;
using Fruits.Data;
using Fruits.Data.Agents;

namespace Fruits.Core.Agents
{
    public class AgentService : IAgentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult> RegisterAgentAsync(AgentModel agent, CancellationToken token = default)
        {
            ValidateAgent(agent);

            var agentDTO = _mapper.Map<AgentModel, Agent>(agent);

            await _unitOfWork.Agents.SaveAsync(agentDTO, token);
            _unitOfWork.Commit();

            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteAgentAsync(long agentId, CancellationToken token = default)
        {
            await _unitOfWork.Agents.DeleteAgent(agentId, token);
            _unitOfWork.Commit();

            return OperationResult.Success();
        }

        private void ValidateAgent(AgentModel agent)
        {
            if (agent == null)
                throw new ArgumentException(nameof(agent));

            if (string.IsNullOrWhiteSpace(agent.FirstName))
                throw new ArgumentNullException(nameof(agent.FirstName));

            if (string.IsNullOrWhiteSpace(agent.LastName))
                throw new ArgumentNullException(nameof(agent.LastName));

            if (string.IsNullOrWhiteSpace(agent.PersonalId) || agent.PersonalId.Length != 11)
                throw new ArgumentException(nameof(agent.PersonalId));
        }
    }
}
