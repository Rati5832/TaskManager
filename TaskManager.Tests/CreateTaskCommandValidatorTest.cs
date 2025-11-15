using FluentAssertions;
using TaskManager.Application.Tasks.Commands.CreateTask;

namespace TaskManager.Tests
{
    public class CreateTaskCommandValidatorTest
    {
        private readonly CreateTaskCommandValidator _validator = new();

        [Fact]
        public void Should_Fail_When_Title_Is_Empty()
        {
            var command = new CreateTaskCommand("");

            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(x => x.PropertyName == "Title");
        }

        [Fact]
        public void Should_Fail_When_Title_Is_Short()
        {
            var command = new CreateTaskCommand("as");
            
            var result = _validator.Validate(command);

            result.IsValid.Should().BeFalse();
        }
    }
}
