using Task3.Models;
using Task3.Repo.Interface;

namespace Task3.Repo
{
    public class ProductRepo : IProductRepo
    {
       private readonly List<Product> _products = new List<Product>();


        public Product Add(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                throw new ArgumentException($"Product with Id {product.Id} already exists.");
            }else
            {
                product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                return product;
            }

        }

        public Product Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new ArgumentException($"Product with Id {id} does not exist.");
            }
            _products.Remove(product);
            return product;

        }

        public List<Product> GetAll()
        {
            return _products;

        }

        public Product? GetbyId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be greater than zero.");
            }
            else
            {
                return _products.FirstOrDefault(p => p.Id == id);
            }
        }

        public Product Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with Id {product.Id} does not exist.");
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            return existingProduct;

        }

        public Product? UpdateName(int id, string name)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with Id {id} does not exist.");
            }
            existingProduct.Name = name;
            return existingProduct;

        }
    }
}
