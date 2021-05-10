using System;

namespace Fruits.Core.Agents
{
    public class AgentModel
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
