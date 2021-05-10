using Fruits.Data.Agents;
using Fruits.Data.Products;
using Fruits.Data.Statements;

namespace Fruits.Data
{
    public interface IUnitOfWork
    {
        public IAgentRepository Agents { get; }
        public IBaseRepository<Statement> Statements { get; }
        public IProductRepository Products { get; }

        public void Commit();
    }
}
