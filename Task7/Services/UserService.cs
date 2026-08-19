using Task7.Models;
using Task7.Repo;
using Task7.Services.Interface;

namespace Task7.Services
{
    public class UserService:IUserService
    {
        private readonly UserRepo _userRopo;
        public UserService(UserRepo userRopo)
        {
            _userRopo = userRopo;
        }

        public Task<User> CreateUser(User user)
        {
           return _userRopo.CreateUser(user);
        }

        public Task<List<User>> GetUsers()
        {
            return _userRopo.GetUsers();
        }
    }
}
