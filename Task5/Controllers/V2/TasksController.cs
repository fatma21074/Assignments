using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Task5.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = new[]
            {
        new { id = 1, title = "Task 1", status = "completed", dueDate = DateTime.UtcNow.AddDays(3), createdAt = DateTime.UtcNow },
        new { id = 2, title = "Task 2", status = "pending",   dueDate = DateTime.UtcNow.AddDays(5), createdAt = DateTime.UtcNow }
    };
            return Ok(tasks);
        }
    }
}