using AutoMapper;
using Task9.Dtos;
using Task9.Models;
using Task9.Repo.Interface;
using Task9.Services.Interface;

namespace Task9.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskItemService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskItemDto> CreateTask(CreateTaskRequest request)
        {
            var entity = _mapper.Map<TaskItem>(request);
            var created = await _taskRepository.CreateTask(entity);
            return _mapper.Map<TaskItemDto>(created);
        }

        public async Task<TaskItemDto?> GetById(int Id)
        {
            var entity = await _taskRepository.GetById(Id);
            return entity is null ? null : _mapper.Map<TaskItemDto>(entity);
        }

        public async Task<(List<TaskSummaryDto> Items, int TotalCount)> GetAll(string? search, bool? isCompleted, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var (items, totalCount) = await _taskRepository.GetAll(search, isCompleted, page, pageSize);
            var dtoItems = _mapper.Map<List<TaskSummaryDto>>(items);
            return (dtoItems, totalCount);
        }

        public async Task<TaskItemDto?> UpdateTask(int Id, UpdateTaskRequest request)
        {
            var entity = _mapper.Map<TaskItem>(request);
            var updated = await _taskRepository.UpdateTask(Id, entity);
            return updated is null ? null : _mapper.Map<TaskItemDto>(updated);
        }

        public Task<bool> DeleteTask(int Id)
        {
            return _taskRepository.DeleteTask(Id);
        }
    }
}
