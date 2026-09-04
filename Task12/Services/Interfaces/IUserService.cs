using Task12.DTOs;
using Task12.Models;

namespace Task12.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUser(Register newUser);
        public Task<List<User>> GetAll();
        public Task<string> Login(Login user);
        public string GenerateToken(User user);


    }
}
