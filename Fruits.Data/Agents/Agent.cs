using System;

namespace Fruits.Data.Agents
{
    public class Agent
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public Agent? Parent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
