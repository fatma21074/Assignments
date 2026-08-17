using Microsoft.AspNetCore.Mvc;
using Task6.Models;
using Task6.Service.Interface;

namespace Task6.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)

        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] TaskFilterParams Param)
        {
            return Ok(_productService.GetAll(Param));
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(_productService.Add(product)); 
        }
    }
}
