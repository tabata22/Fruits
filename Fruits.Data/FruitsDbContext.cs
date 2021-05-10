using Fruits.Data.Agents;
using Fruits.Data.Products;
using Fruits.Data.Statements;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Data
{
    public class FruitsDbContext : DbContext
    {
        public FruitsDbContext(DbContextOptions<FruitsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Statement> Statements { get; set; }
    }
}
