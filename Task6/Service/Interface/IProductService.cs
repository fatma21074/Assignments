using Task6.Models;

namespace Task6.Service.Interface
{
    public interface IProductService
    {
        public PagedResult<Product> GetAll(TaskFilterParams param);
        public Product Add(Product product);
    }
}
