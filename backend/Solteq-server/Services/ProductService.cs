


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

        public async Task<List<GenericProduct>> GetGenericProductDetailsAsync()
        {
            return await _context.GenericProducts.ToListAsync();
        }
        public async Task<List<GenericProduct>> GetFilteredProductDetailsAsync(string query)
        {
            var products = await _context.GenericProducts.ToListAsync();
            if(string.IsNullOrWhiteSpace(query))
            {
                return products;
            }
            var lowerCaseQuery = query.ToLower();
            var filteredProducts = products.Where(p => p.ProductName.ToLower().Contains(lowerCaseQuery)
            || p.Id.ToString().Contains(lowerCaseQuery)).ToList();

            return filteredProducts;
        }
    }
}
