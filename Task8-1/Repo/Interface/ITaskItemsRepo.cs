using Task8.Models;

namespace Task8.Repo.Interface
{
    public interface ITaskItemsRepo
    {
        public Task<TaskItem> CreateTask(TaskItem task);
        public Task<TaskItem?> GetById(int Id);
        public Task<(List<TaskItem> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize);
        public Task<TaskItem?> UpdateTask(int Id, TaskItem updated);
        public Task<bool> DeleteTask(int Id);
    }
}
