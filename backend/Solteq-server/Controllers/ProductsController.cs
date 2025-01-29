

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solteq_server.services;

namespace Solteq_server.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            
            return Ok(products);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> GetSingleProduct(long id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);
        }

        [HttpGet("nutrition")]
        public async Task<IActionResult> GetAllNutritionalValues()
        {
            var nutritionalDetails = await _productService.GetAllNutritionalDetailsAsync();

            return Ok(nutritionalDetails);
        }
    }
}
