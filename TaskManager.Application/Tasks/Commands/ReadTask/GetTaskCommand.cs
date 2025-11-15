using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.ReadTask
{
    public record GetTaskCommand : IRequest<TodoTaskResponseDto>
    {
        public Guid Id { get; set; }
    }
}
