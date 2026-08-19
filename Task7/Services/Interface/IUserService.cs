using Task7.Models;

namespace Task7.Services.Interface
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
