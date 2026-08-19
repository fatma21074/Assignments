using Microsoft.AspNetCore.Mvc;
using Task7.Models;
using Task7.Services.Interface;

namespace Task7.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskItemController : Controller
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService= taskItemService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var date = await _taskItemService.GetById(id);

            return Ok(new
            {
                TaskId = date.Id,
                Title= date.Title,
                Description=date.Description,
                UserId=date.UserId,
                Name=date.User.Name
            });

        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskItem task)
        {
            return Created($"/api/task/{task.Id}",await  _taskItemService.CreateTask(task));
        }
    }
}
