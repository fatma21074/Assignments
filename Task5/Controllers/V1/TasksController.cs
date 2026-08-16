using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Task5.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = new[]
            {
                 new { id = 1, title = "Task 1", isCompleted = true },
                 new { id = 2, title = "Task 2", isCompleted = false }
            };
            return Ok(tasks);
        }
       
    }
}
