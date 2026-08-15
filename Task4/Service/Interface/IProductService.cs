using Task4.Models;

namespace Task4.Service.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product? GetbyId(int id);
        public Product Add(Product product);
        public Product Update(Product product);
        public Product Delete(int id);
        public Product? UpdateName(int id, string name);



    }
}
