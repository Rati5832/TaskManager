namespace TaskManager.Domain.Entities;

public class TodoTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}
