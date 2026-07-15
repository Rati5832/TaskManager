using FluentValidation;
using TaskManager.Application.Common.Interfaces;


namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        private readonly ITaskRepository _context;

        public UpdateTaskValidator(ITaskRepository context)
        {
            _context = context;

            RuleFor(x => x)
                .NotEmpty()
                .MustAsync(ShouldDifferentTitle)
                .WithMessage("The new title must be different from the current one");
        }

        private async Task<bool> ShouldDifferentTitle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await _context.GetTaskById(command.Id, cancellationToken);

            return task is null || task.Title != command.Title;
        }
    }
}
