
using Task8.Models;
using Task8.Repo.Interface;
using Task8.Services.Interface;

namespace Task8.Services
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

        public Task<TaskItem?> GetById(int Id)
        {
           return _taskItemRepo.GetById(Id);
        }

        public Task<(List<TaskItem> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize)
        {
            // حماية بسيطة من قيم page/pageSize غير منطقية جاية من الـ query string
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            return _taskItemRepo.GetAll(search, isCompleted, page, pageSize);
        }

        public Task<TaskItem?> UpdateTask(int Id, TaskItem updated)
        {
            return _taskItemRepo.UpdateTask(Id, updated);
        }

        public Task<bool> DeleteTask(int Id)
        {
            return _taskItemRepo.DeleteTask(Id);
        }
    }
}
