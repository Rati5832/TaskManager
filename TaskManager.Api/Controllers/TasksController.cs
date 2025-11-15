using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Tasks.Commands.CreateTask;
using TaskManager.Application.Tasks.Commands.DeleteTask;
using TaskManager.Application.Tasks.Commands.ReadTask;
using TaskManager.Application.Tasks.Commands.UpdateTask;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, id);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var command = new GetTaskCommand { Id = id };

            var task = await _mediator.Send(command);
            if (task is null) return NotFound();

            return Ok(task);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTaskCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand { Id = id };

            var result = await _mediator.Send(command);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
