using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task7.Models;
using Task7.Services;
using Task7.Services.Interface;

namespace Task7.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userService.GetUsers());

        }
        [HttpPost]
        public async Task<IActionResult> CreatUser(User user)
        {
            return Created($"/api/user/{user.Id}",await _userService.CreateUser(user));

        }
    }
}
