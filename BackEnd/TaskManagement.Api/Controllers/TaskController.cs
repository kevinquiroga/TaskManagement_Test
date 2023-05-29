using System;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Entities;
using static TaskManagement.Application.Commands.Commands;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController:ControllerBase
	{
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateTask(CreateTaskCommand command)
        {
            try
            {
                var tareaId = await _mediator.Send(command);
                return Ok(tareaId);
            }
            catch(Exception ex)
            {
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTarea(int id, UpdateTaksCommand command)
        {
            if (id != command.IdTask)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            var query = new DeleteTaskCommand{ IdTask = id };
            var tarea = await _mediator.Send(query);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> ObtenerTarea(int id)
        {
            var query = new TaskQueryCommand { IdTask = id };
            var tarea = await _mediator.Send(query);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> ObtenerTareas()
        {
            var query = new AllTaskQueryCommand();
            var tareas = await _mediator.Send(query);
            return Ok(tareas);
        }
    }
}

