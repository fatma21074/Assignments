using Microsoft.EntityFrameworkCore;
using Task8.ApplicationDbcontext;
using Task8.Models;
using Task8.Repo.Interface;

namespace Task8.Repo
{
    public class UserRepo:IUserRepo
    {
        private readonly ApplicationDbContext _context;
       public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
