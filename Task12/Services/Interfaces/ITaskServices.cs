using Task12.Models;

namespace Task12.Services.Interfaces
{
    public interface ITaskServices
    {
        public Task<TaskItem> CreateTask(TaskItem product);
        public Task<IEnumerable<TaskItem>> GetAll();
        public Task<TaskItem> GetTaskById(int id);

    }
}
