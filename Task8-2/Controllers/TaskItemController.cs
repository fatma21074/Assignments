using Microsoft.AspNetCore.Mvc;
using Task9.Dtos;
using Task9.Services.Interface;

namespace Task9.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] bool? isCompleted, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var (items, totalCount) = await _taskItemService.GetAll(search, isCompleted, page, pageSize);
            return Ok(new { items, totalCount, page, pageSize });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskItemService.GetById(id);
            if (task is null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequest request)
        {
            var created = await _taskItemService.CreateTask(request);
            return Created($"/api/tasks/{created.Id}", created);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskRequest request)
        {
            var updated = await _taskItemService.UpdateTask(id, request);
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
