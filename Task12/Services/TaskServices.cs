using Task12.Models;
using Task12.Repistories;
using Task12.Repistories.Interfaces;
using Task12.Services.Interfaces;

namespace   Task12.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepistory _taskRepistory;

        public TaskServices(ITaskRepistory taskRepistory)
        {
            _taskRepistory = taskRepistory;
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            return await _taskRepistory.CreateTask(task);
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _taskRepistory.GetAll();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            return await _taskRepistory.GetTaskById(id);
        }
    }
}
