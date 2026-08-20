using Task9.Models;

namespace Task9.Repo.Interface
{
    public interface ITaskRepository
    {
        public Task<TaskItem> CreateTask(TaskItem task);
        public Task<TaskItem?> GetById(int Id);
        public Task<(List<TaskItem> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize);
        public Task<TaskItem?> UpdateTask(int Id, TaskItem updated);
        public Task<bool> DeleteTask(int Id);
    }
}
