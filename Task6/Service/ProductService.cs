using Task6.Models;
using Task6.Repo.Interface;
using Task6.Service.Interface;

namespace Task6.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _product;
        ProductService(IProductRepo productRepo)
        {
            _product = productRepo;
        }

        public Product Add(Product product)
        {
           return _product.Add(product);
        }

        public PagedResult<Product> GetAll(TaskFilterParams param)
        {
            return _product.GetAll(param);
        }
    }
}
