using Task8.Models;

namespace Task8.Repo.Interface
{
    public interface IUserRepo
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
