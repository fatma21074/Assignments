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
           return _productRepo.Add(product);
            
        }

        public Product Delete(int id)
        {
            return _productRepo.Delete(id);

        }

        public List<Product> GetAll()
        {
            return _productRepo.GetAll();
        }

        public Product? GetbyId(int id)
        {
            return _productRepo.GetbyId(id);
        }

        public Product Update(Product product)
        {
            return _productRepo.Update(product);
        }

        public Product? UpdateName(int id, string name)
        {
            return _productRepo.UpdateName(id, name);
        }
    }
}
