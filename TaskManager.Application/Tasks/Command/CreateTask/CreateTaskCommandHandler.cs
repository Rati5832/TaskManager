using AutoMapper;
using MediatR;

using TaskManager.Application.Common.Interfaces;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TodoTaskResponseDto>
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TodoTaskResponseDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        { 
            var task = await _repository.CreateTaskAsync(new TodoTask { Title = request.Title, IsCompleted = false }, cancellationToken);

            return _mapper.Map<TodoTaskResponseDto>(task);
        }
    }
}
