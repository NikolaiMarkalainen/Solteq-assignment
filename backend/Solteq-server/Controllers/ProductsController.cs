

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solteq_server.services;

namespace Solteq_server.controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("generics")]
        public async Task<IActionResult> GetGenericProducts()
        {
            var products = await _productService.GetGenericProductDetailsAsync();
            return Ok(products);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            
            return Ok(products);
        }

        [HttpGet("{id}")]
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
        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetProductImage(long id)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "images", $"{id}.png");

            if(!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }
            var fileStream = System.IO.File.OpenRead(imagePath);
            return File(fileStream, "image/png");
        }
        [HttpGet("generics/{query}")]
        public async Task<IActionResult> GetFilteredProducts(string query)
        {
            var products = await _productService.GetFilteredProductDetailsAsync(query);

            return Ok(products);
        }
    }
}
