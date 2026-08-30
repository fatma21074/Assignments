using Microsoft.AspNetCore.Mvc;
using Task10.Dtos;
using Task10.Models;

namespace Task10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static readonly List<TaskItem> _tasks = new();
        private static int _nextId = 1;

        [HttpPost]
        public IActionResult Create(CreateTaskRequest request)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = request.Title,
                DueDate = request.DueDate,
                CreatedAt = DateTime.UtcNow
            };

            _tasks.Add(task);

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }
    }
}
