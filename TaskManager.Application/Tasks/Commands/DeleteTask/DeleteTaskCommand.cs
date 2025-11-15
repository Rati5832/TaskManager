
using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand() : IRequest<TodoTaskResponseDto>
    {
        public Guid Id { get; set; }
    }
}
