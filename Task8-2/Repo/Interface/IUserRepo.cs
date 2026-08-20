using Task9.Models;

namespace Task9.Repo.Interface
{
    public interface IUserRepo
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
