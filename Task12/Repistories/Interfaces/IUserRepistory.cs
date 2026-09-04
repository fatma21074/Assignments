using Task12.DTOs;
using Task12.Models;

namespace Task12.Repistories.Interfaces
{
    public interface IUserRepistory
    {
        public Task<User> CreateUser(User newUser);
        public Task<List<User>> GetAll();
        public Task<User> Login(Login user);
    }
}
