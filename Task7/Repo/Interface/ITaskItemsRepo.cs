using Task7.Models;

namespace Task7.Repo.Interface
{
    public interface ITaskItemsRepo
    {
        public Task<TaskItem> CreateTask(TaskItem task);
        public Task<TaskItem> GetById(int Id);
    }
}
