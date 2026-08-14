using Microsoft.AspNetCore.Mvc;
using Task3.Models;
using Task3.Service.Interface;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {

       private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetbyId(id);

            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            var addedProduct = _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = addedProduct.Id }, addedProduct);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {

            var updatedProduct = _productService.Update(product);
            return Ok(updatedProduct);
        }
        [HttpPatch("{id}/name")]
        public IActionResult UpdateName(int id, string name)
        {
            var updatedProduct = _productService.UpdateName(id, name);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedProduct = _productService.Delete(id);
            return Ok(deletedProduct);
        }

    }
}
