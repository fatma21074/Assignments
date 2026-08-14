using Task3.Models;
namespace Task3.Repo.Interface
{
    public interface IProductRepo
    {
        public List<Product> GetAll();
        public Product? GetbyId(int id);
        public Product Add(Product product);
        public Product Update(Product product);
        public Product Delete(int id);
        public Product? UpdateName(int id, string name);

    }
}
