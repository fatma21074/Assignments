using Task7.Models;

namespace Task7.Services.Interface
{
    public interface ITaskItemService
    {
        public Task<TaskItem> CreateTask(TaskItem task);
        public Task<TaskItem> GetById(int Id);
    }
}
