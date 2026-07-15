
using MediatR;

namespace TaskManager.Application.Tasks.Commands.DeleteTask
{
    public record DeleteTaskCommand(Guid Id) : IRequest<bool>
    {
    }
}
