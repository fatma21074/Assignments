using Task3.Models;

namespace Task3.Service.Interface
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetbyId(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
        Product? UpdateName(int id, string name);


    }
}
