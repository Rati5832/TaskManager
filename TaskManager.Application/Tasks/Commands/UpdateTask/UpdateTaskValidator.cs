using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Common.Interfaces;


namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTaskValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x)
                .NotEmpty()
                .MustAsync(ShouldDifferentTitle)
                .WithMessage("The new title must be different from the current one");
        }

        private async Task<bool> ShouldDifferentTitle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            return task is null || task.Title != command.Title;
        }
    }
}
