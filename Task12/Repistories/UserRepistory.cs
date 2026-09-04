using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Task12.Data;
using Task12.DTOs;
using Task12.Models;
using Task12.Repistories.Interfaces;

namespace Task12.Repistories
{
    public class UserRepistory : IUserRepistory
    {
        private ApplicationDbContext _dbContext;

        public UserRepistory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(User newUser)
        {
            _dbContext.User.Add(newUser);

            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<User> Login(Login user)
        {
            var userFound = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userFound is null || !BCrypt.Net.BCrypt.Verify(user.Password, userFound.PasswordHash))
                return null;

            return userFound;
        }
    }
}
