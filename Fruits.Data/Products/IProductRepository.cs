using System.Threading;
using System.Threading.Tasks;

namespace Fruits.Data.Products
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task ReduceProductAsync(long productId, int reduceCount, CancellationToken token = default);
        Task<bool> CheckProductAvailabilityAsync(long productId, int checkCount, CancellationToken token = default);
    }
}
