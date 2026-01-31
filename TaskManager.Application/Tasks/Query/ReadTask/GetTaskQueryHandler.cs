using AutoMapper;
using MediatR;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Tasks.Commands.ReadTask
{
    public class GetTaskCommandHandler : IRequestHandler<GetTaskQuery, TodoTaskResponseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoTaskResponseDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id, cancellationToken);
            if (task is null) return null;

            return _mapper.Map<TodoTaskResponseDto>(task);
        }
    }
}
