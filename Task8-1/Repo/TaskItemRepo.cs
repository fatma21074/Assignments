using Microsoft.EntityFrameworkCore;
using Task8.ApplicationDbcontext;
using Task8.Models;
using Task8.Repo.Interface;

namespace Task8.Repo
{
    public class TaskItemRepo:ITaskItemsRepo
    {
        private readonly ApplicationDbContext _dbcontext;
        public TaskItemRepo(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            _dbcontext.TaskItems.Add(task);
            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskItem?> GetById(int Id)
        {
            var Query = _dbcontext.TaskItems.AsQueryable();
            Query = Query.Include(x => x.User).Where(x => x.Id == Id);
            var task = await Query.SingleOrDefaultAsync();
            return task;
        }

        public async Task<(List<TaskItem> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize)
        {
            var query = _dbcontext.TaskItems.Include(x => x.User).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(searchLower));
            }

            if (isCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == isCompleted.Value);
            }

            // لازم نحسب الـ Count قبل الـ Skip/Take عشان يبقى إجمالي العدد الحقيقي للنتائج المطابقة، مش عدد الصفحة بس
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<TaskItem?> UpdateTask(int Id, TaskItem updated)
        {
            var task = await _dbcontext.TaskItems.FindAsync(Id);
            if (task is null) return null;

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.IsCompleted = updated.IsCompleted;

            await _dbcontext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int Id)
        {
            var task = await _dbcontext.TaskItems.FindAsync(Id);
            if (task is null) return false;

            _dbcontext.TaskItems.Remove(task);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
