using Fruits.Data.Agents;

namespace Fruits.Data.Statements
{
    public class Statement
    {
        public long Id { get; set; }
        public long AgentId { get; set; }
        public Agent Agent { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; }
    }
}
