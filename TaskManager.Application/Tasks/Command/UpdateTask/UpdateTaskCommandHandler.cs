
using AutoMapper;
using MediatR;
using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TodoTaskResponseDto?>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoTaskResponseDto?> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<TodoTask>(request);

            var update = await _repository.UpdateTaskByIdAsync(request.Id, task, cancellationToken);
            if (!update)
            {
                return null;
            }

            return _mapper.Map<TodoTaskResponseDto>(task);
        }
    }
}
