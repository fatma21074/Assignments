using Task3.Models;
using Task3.Repo.Interface;

namespace Task3.Repo
{
    public class ProductRepo : IProductRepo
    {
       private readonly List<Product> _products = new List<Product>();


        public Product Add(Product product)
        {
            _products.Add(product);
            return product;

        }

        public Product Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
           
            _products.Remove(product);
            return product;

        }

        public List<Product> GetAll()
        {
            return _products;

        }

        public Product? GetbyId(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            return existingProduct;

        }

        public Product? UpdateName(int id, string name)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
           
            existingProduct.Name = name;
            return existingProduct;

        }
    }
}
