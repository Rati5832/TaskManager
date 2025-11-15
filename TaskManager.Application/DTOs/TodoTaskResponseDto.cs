
namespace TaskManager.Application.DTOs
{
    public class TodoTaskResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
