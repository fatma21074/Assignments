using Task9.Models;
using Task9.Repo.Interface;
using Task9.Services.Interface;

namespace Task9.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRopo;
        public UserService(IUserRepo userRopo)
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
