using Task3.Models;
using Task3.Repo.Interface;
using Task3.Service.Interface;

namespace Task3.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
      public  ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Product Add(Product product)
        {
            if (_productRepo.GetAll().Any(p => p.Name == product.Name))
            {
                throw new Exception("Product with the same name already exists.");
            }
            return _productRepo.Add(product);

        }

        public Product Delete(int id)
        {
            if (_productRepo.GetAll().Any(p => p.Id == id) == false)
            {
                throw new Exception("Product with the given id does not exist.");
            }
            return _productRepo.Delete(id);

        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public Product? GetbyId(int id)
        {
            var product = _productRepo.GetbyId(id);
            if (product == null)
            {
                throw new Exception("Product with the given id does not exist.");
            }
            return _productRepo.GetbyId(id);
        }

        public Product Update(Product product)
        {
            if (_productRepo.GetAll().Any(p => p.Id == product.Id) == false)
            {
                throw new Exception("Product with the given id does not exist.");
            }
            return _productRepo.Update(product);
        }

        public Product? UpdateName(int id, string name)
        {
            if (_productRepo.GetAll().Any(p => p.Id == id) == false)
            {
                throw new Exception("Product with the given id does not exist.");
            }
            return _productRepo.UpdateName(id, name);
        }
    }
}
