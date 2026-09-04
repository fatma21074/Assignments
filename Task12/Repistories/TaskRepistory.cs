using Task12.Data;
using Task12.Models;
using Task12.Repistories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Task12.Repistories
{
    public class TaskRepistory : ITaskRepistory
    {
        private ApplicationDbContext _dbContext;

        public TaskRepistory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            _dbContext.TaskItem.Add(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _dbContext.TaskItem.ToListAsync();
        }

        public async Task<TaskItem> GetTaskById(int id)
        {
            var task = await _dbContext.TaskItem.FindAsync(id);

            return task;
        }
    }
}
