using Task12.Models;
using Task12.Repistories.Interfaces;
using Task12.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task12.DTOs;

namespace Task12.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepistory _userRepistory;
        private readonly IConfiguration _config;

        public UserService(IUserRepistory userRepistory, IConfiguration config)
        {
            _userRepistory = userRepistory;
            _config = config;
        }

        public async Task<User> CreateUser(Register newUser)
        {
            var user = new User
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = newUser.Role,
                Department = newUser.Department
            };

            return await _userRepistory.CreateUser(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepistory.GetAll();
        }

        public async Task<string> Login(Login user)
        {
            var userFound = await _userRepistory.Login(user);

            if (userFound == null) return null;


            // Generate token 


            var token = GenerateToken(userFound);

            return token;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("Department", user.Department.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(_config["Jwt:ExpiryMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
