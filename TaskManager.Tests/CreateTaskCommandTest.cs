using Moq;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.Tasks.Commands.CreateTask;
using TaskManager.Domain.Entities;

namespace TaskManager.Tests;

public class CreateTaskCommandTest
{
    [Fact]
    public async Task CreateTask_ShouldReturnId()
    {
        var repo = new Mock<ITaskRepository>();
        var expectedId = Guid.NewGuid();

        repo.Setup(r => r.CreateTaskAsync(It.IsAny<TodoTask>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedId);

        var handler = new CreateTaskCommandHandler(repo.Object);

        var result = await handler.Handle(new CreateTaskCommand("Hello"), CancellationToken.None);

        Assert.Equal(expectedId, result);

        repo.Verify(r => r.CreateTaskAsync(
                It.Is<TodoTask>(task => task.Title == "Hello"),
                It.IsAny<CancellationToken>()),
                Times.Once);
    }
}
