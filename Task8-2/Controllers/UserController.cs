using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task9.Models;
using Task9.Services;
using Task9.Services.Interface;

namespace Task9.Controllers
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
