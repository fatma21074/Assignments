using Task8.Models;

namespace Task8.Services.Interface
{
    public interface ITaskItemService
    {
        public Task<TaskItem> CreateTask(TaskItem task);
        public Task<TaskItem?> GetById(int Id);
        public Task<(List<TaskItem> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize);
        public Task<TaskItem?> UpdateTask(int Id, TaskItem updated);
        public Task<bool> DeleteTask(int Id);
    }
}
