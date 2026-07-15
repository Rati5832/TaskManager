using TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.Interfaces
{
    public interface ITaskRepository
    {

        Task<TodoTask?> GetTaskById(Guid id, CancellationToken cancellationToken);

        Task<TodoTask> CreateTaskAsync(TodoTask task, CancellationToken cancellationToken);

        Task<bool> UpdateTaskByIdAsync(Guid id, TodoTask task, CancellationToken cancellationToken);

        Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
