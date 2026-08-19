using Task7.Models;

namespace Task7.Repo.Interface
{
    public interface IUserRpo
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
