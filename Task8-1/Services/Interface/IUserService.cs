using Task8.Models;

namespace Task8.Services.Interface
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetUsers();
    }
}
