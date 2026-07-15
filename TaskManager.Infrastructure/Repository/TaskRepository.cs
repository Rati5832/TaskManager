using TaskManager.Application.Common.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Guid> CreateTaskAsync(TodoTask task, CancellationToken cancellationToken)
        {
            await _appDbContext.Tasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }

        public async Task<bool> DeleteTaskByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Tasks.FindAsync(id, cancellationToken);
            if (entity == null) return false;

            _appDbContext.Tasks.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<TodoTask?> GetTaskById(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Tasks.FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateTaskByIdAsync(Guid id, TodoTask task, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Tasks.FindAsync(id, cancellationToken);
            if (entity == null) return false;

            entity.Title = task.Title;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
