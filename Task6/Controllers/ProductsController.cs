using Microsoft.AspNetCore.Mvc;
using Task6.Models;
using Task6.Service.Interface;

namespace Task6.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        ProductsController(IProductService productService)
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
