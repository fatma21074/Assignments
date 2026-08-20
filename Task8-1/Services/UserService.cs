using Task8.Models;
using Task8.Repo.Interface;
using Task8.Services.Interface;

namespace Task8.Services
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
