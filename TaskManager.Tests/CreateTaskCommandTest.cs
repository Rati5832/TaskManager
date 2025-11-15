using Microsoft.EntityFrameworkCore;
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
        var repo = new Mock<IApplicationDbContext>();
        var mockSet = new Mock<DbSet<TodoTask>>();

        repo.Setup(r => r.Tasks).Returns(mockSet.Object);
        repo.Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var handler = new CreateTaskCommandHandler(repo.Object);


        var result = await handler.Handle(new CreateTaskCommand("Hello"), CancellationToken.None);

        Assert.NotEqual(Guid.Empty, result);
        mockSet.Verify(m => m.Add(It.IsAny<TodoTask>()), Times.Once);
        repo.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
