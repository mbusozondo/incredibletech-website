using INCREDIBLE_TECH__LTD_.Data.Base;
using INCREDIBLE_TECH__LTD_.Models;

namespace INCREDIBLE_TECH__LTD_.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int ProductId);
        Task AddAsync(Product product);
        Task<Product> UpdateAsync(int ProductId, Product newProduct);
        void Delete(int ProductId);
    }
}
