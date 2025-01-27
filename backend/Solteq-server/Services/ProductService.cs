


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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try{
                return await _context.Products.Include(p => p.NutritionalDetails).FirstOrDefaultAsync(p => p.Id == id);
            } catch(Exception e) {
                Console.WriteLine($"An error occurred: {e.Message}");
                return null;
            }
        }
        public async Task<List<NutritionalDetails>> GetAllNutritionalDetailsAsync()
        {
            return await _context.NutritionalDetails.ToListAsync();
        }
    }
}
