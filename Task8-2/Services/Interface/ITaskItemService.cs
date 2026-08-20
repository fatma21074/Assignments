using Task9.Dtos;

namespace Task9.Services.Interface
{
    public interface ITaskItemService
    {
        public Task<TaskItemDto> CreateTask(CreateTaskRequest request);
        public Task<TaskItemDto?> GetById(int Id);
        public Task<(List<TaskSummaryDto> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize);
        public Task<TaskItemDto?> UpdateTask(int Id, UpdateTaskRequest request);
        public Task<bool> DeleteTask(int Id);
    }
}
