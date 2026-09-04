using Task12.Models;

namespace Task12.Repistories.Interfaces
{
    public interface ITaskRepistory
    {
        public Task<TaskItem> CreateTask(TaskItem product);
        public Task<IEnumerable<TaskItem>> GetAll();

        public Task<TaskItem> GetTaskById(int id);

    }
}
