
using Task7.Models;
using Task7.Repo.Interface;
using Task7.Services.Interface;

namespace Task7.Services
{
    public class TaskItemService:ITaskItemService
    {
        private readonly ITaskItemsRepo _taskItemRepo;
        public TaskItemService(ITaskItemsRepo taskItemRepo)
        {
            _taskItemRepo = taskItemRepo;
        }

        public Task<TaskItem> CreateTask(TaskItem task)
        {
            return _taskItemRepo.CreateTask(task);
        }

        public Task<TaskItem> GetById(int Id)
        {
           return _taskItemRepo.GetById(Id);
        }
    }
}
