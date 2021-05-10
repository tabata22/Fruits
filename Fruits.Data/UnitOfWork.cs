using Fruits.Data.Agents;
using Fruits.Data.Products;
using Fruits.Data.Statements;

namespace Fruits.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FruitsDbContext _context;
        private IAgentRepository _agentRepository;
        private IBaseRepository<Statement> _statementRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(FruitsDbContext context) => _context = context;

        public IAgentRepository Agents
        {
            get { return _agentRepository ??= new AgentRepository(_context); }
        }

        public IBaseRepository<Statement> Statements
        {
            get { return _statementRepository ??= new BaseRepository<Statement>(_context); }
        }

        public IProductRepository Products
        {
            get { return _productRepository ??= new ProductRepository(_context); }
        }

        public void Commit() => _context.SaveChanges();
    }
}
