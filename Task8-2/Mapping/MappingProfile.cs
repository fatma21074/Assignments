using AutoMapper;
using Task9.Dtos;
using Task9.Models;

namespace Task9.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null));

            CreateMap<TaskItem, TaskSummaryDto>();

            CreateMap<CreateTaskRequest, TaskItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateTaskRequest, TaskItem>();
        }
    }
}
