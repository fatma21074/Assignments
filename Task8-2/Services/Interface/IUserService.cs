using Task9.Models;

namespace Task9.Services.Interface
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
