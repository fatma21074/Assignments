using Task3.Models;
namespace Task3.Repo.Interface
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product? GetbyId(int id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(int id);
        Product? UpdateName(int id, string name);

    }
}
