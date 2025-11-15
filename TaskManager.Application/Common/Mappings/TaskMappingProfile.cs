using AutoMapper;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.Mappings
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TodoTask, TodoTaskResponseDto>();
        }
    }
}
