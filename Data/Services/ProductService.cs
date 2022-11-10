
using INCREDIBLE_TECH__LTD_.Data.Base;

using INCREDIBLE_TECH__LTD_.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace INCREDIBLE_TECH__LTD_.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {

        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) : base(context)

        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public void Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }
        public async Task<Product> GetByIdAsync(int productId)
        {
            var result = await _context.Products.FirstOrDefaultAsync(n => n.Id == productId);
            return result;
        }

        public async Task<Product> UpdateAsync(int ProductId, Product newProduct)
        {
            _context.Update(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }
    }
}
