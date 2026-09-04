using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task12.DTOs;
using Task12.Services.Interfaces;

namespace Task12.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateUser(Register newUser)
        {
            return Ok(await _userService.CreateUser(newUser));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(Login user)
        {
            var token = await _userService.Login(user);
            return Ok(new { accesToken = token });
        }

        [HttpGet]
        [Authorize(Roles = "Admin", Policy = "ITAdmin")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }


        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var department = User.FindFirst("Department")?.Value;

            return Ok(new { userId, email, role, department });
        }
    }
}
