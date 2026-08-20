using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task8.Models;
using Task8.Services;
using Task8.Services.Interface;

namespace Task8.Controllers
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
