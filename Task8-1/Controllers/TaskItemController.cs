using Microsoft.AspNetCore.Mvc;
using Task8.Models;
using Task8.Services.Interface;

namespace Task8.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService= taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] bool? isCompleted, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var (items, totalCount) = await _taskItemService.GetAll(search, isCompleted, page, pageSize);

            return Ok(new
            {
                items = items.Select(t => new
                {
                    TaskId = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    UserId = t.UserId,
                    Name = t.User?.Name
                }),
                totalCount,
                page,
                pageSize
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskItemService.GetById(id);
            if (task is null) return NotFound();

            return Ok(new
            {
                TaskId = task.Id,
                Title= task.Title,
                Description=task.Description,
                IsCompleted = task.IsCompleted,
                UserId=task.UserId,
                Name=task.User?.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskItem task)
        {
            var created = await _taskItemService.CreateTask(task);
            return Created($"/api/tasks/{created.Id}", created);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task)
        {
            var updated = await _taskItemService.UpdateTask(id, task);
            if (updated is null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskItemService.DeleteTask(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
