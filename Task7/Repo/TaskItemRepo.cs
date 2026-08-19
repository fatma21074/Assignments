using Microsoft.EntityFrameworkCore;
using Task7.ApplicationDbcontext;
using Task7.Models;
using Task7.Repo.Interface;

namespace Task7.Repo
{
    public class TaskItemRepo:ITaskItemsRepo
    {
        private readonly ApplicationDbContext _dbcontext;
        public TasakItemRepo(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            _dbcontext.TaskItems.Add(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem> GetById(int Id)
        {
            var Query = _dbcontext.TaskItems.AsQueryable();
            Query = Query.Include(x => x.User).Where(x => x.Id == Id);
            var task = await Query.SingleAsync();
            return task;
        }
    }
}
