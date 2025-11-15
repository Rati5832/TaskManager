
using AutoMapper;
using MediatR;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TodoTaskResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoTaskResponseDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id, cancellationToken);
            if (task == null) return null;

            task.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TodoTaskResponseDto>(task);
        }
    }
}
