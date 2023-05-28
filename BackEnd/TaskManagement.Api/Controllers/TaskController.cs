using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var tareaId = await _mediator.Send(command);
            return Ok(tareaId);
        }
    }
}

