using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand(string Title) : IRequest<TodoTaskResponseDto>;
}
