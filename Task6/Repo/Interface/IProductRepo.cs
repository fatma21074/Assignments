using Task6.Models;

namespace Task6.Repo.Interface
{
    public interface IProductRepo
    {
        public PagedResult<Product> GetAll(TaskFilterParams param);
        public Product Add(Product product);


    }
}
