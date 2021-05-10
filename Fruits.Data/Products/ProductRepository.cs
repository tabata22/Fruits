using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Data.Products
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FruitsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task ReduceProductAsync(long productId, int reduceCount, CancellationToken token = default)
        {
            var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == productId, token);

            product.Quantity -= reduceCount;
        }

        public async Task<bool> CheckProductAvailabilityAsync(long productId, int checkCount, CancellationToken token = default)
        {
            var product = await DbContext.Products.FindAsync(productId);

            return product.Quantity >= checkCount;
        }
    }
}
