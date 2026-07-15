using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(string Title) : IRequest<TodoTaskResponseDto?>
    {
        public Guid Id { get; set; }
    }
}
