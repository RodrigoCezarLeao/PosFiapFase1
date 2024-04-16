using DesafioAPI.Models;
using DesafioAPI.Repositories.Interfaces;
using DesafioAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    public class ProductController : Controller
    {        
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            
            _productService = productService;
        }


        [HttpPost("/add")]
        public IActionResult InsertProduct(Product product)
        {
            if (!_productService.isProductValid(product))
                return BadRequest("Produto inserido não é válido!");

            product.Id = Guid.NewGuid();
            var result = _productService.InsertProduct(product);
            return Ok(result);
        }

        [HttpGet("/")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productService.GetAllProducts();

            if (allProducts.Any())
                return Ok(allProducts);
            else
                return NoContent();
        }


        
    }
}
