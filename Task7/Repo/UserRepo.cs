using Microsoft.EntityFrameworkCore;
using Task7.ApplicationDbcontext;
using Task7.Models;
using Task7.Repo.Interface;

namespace Task7.Repo
{
    public class UserRepo:IUserRpo
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
