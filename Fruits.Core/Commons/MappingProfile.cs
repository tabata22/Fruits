using AutoMapper;
using Fruits.Core.Agents;
using Fruits.Core.Statements;
using Fruits.Data.Agents;
using Fruits.Data.Statements;

namespace Fruits.Core.Commons
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AgentModel, Agent>();
            CreateMap<StatementModel, Statement>();
        }
    }
}
