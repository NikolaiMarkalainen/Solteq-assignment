


using Microsoft.EntityFrameworkCore;
using Solteq_server.data;
using Solteq_server.models;

namespace Solteq_server.services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GenericProduct>> GetGenericProductDetailsAsync()
        {
            return await _context.Products.Select(p => new GenericProduct
            {
                Id = p.Id,
                ProductName = p.ProductName,
            }).ToListAsync();
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.NutritionalDetails).ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(long id)
        {
            var product = await _context.Products.Include(p => p.NutritionalDetails).FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
        public async Task<List<NutritionalDetails>> GetAllNutritionalDetailsAsync()
        {
            return await _context.NutritionalDetails.ToListAsync();
        }
    }
}
