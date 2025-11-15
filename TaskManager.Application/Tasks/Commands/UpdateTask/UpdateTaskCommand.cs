using MediatR;
using System.Text.Json.Serialization;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand(string Title) : IRequest<TodoTaskResponseDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
