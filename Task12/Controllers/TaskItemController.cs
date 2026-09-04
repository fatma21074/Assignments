using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task12.Helper;
using Task12.Models;
using Task12.Services.Interfaces;

namespace Task12.Controllers
{
    [ApiController]
    [Route("/api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        private readonly IAuthorizationService _authz;

        public TaskController(ITaskServices taskServices, IAuthorizationService authz)
        {
            _taskServices = taskServices;
            _authz = authz;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(TaskItem task)
        {
            return Created($"/api/task/{task.Id}", await _taskServices.CreateTask(task));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var task = await _taskServices.GetTaskById(id);

            var result = await _authz.AuthorizeAsync(User, task, Operations.Read);

            if (!result.Succeeded) return Forbid();

            return Ok(task);
        }


        [HttpGet]
        [Authorize(Roles = "Admin", Policy = "ITAdmin")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _taskServices.GetAll());
        }
    }
}
