using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TodoTask> Tasks => Set<TodoTask>();
}
