using AutoMapper;
using MediatR;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, TodoTaskResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<TodoTaskResponseDto> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.Tasks.FindAsync(request.Id, cancellationToken);
            if (existing is null) return null;

            _context.Tasks.Remove(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TodoTaskResponseDto>(existing);
        }
    }
}
