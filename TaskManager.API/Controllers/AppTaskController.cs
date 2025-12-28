using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.AddAppTask;
using TaskManager.Application.Commands.AddSecurityGroup;
using TaskManager.Application.Queries.GetAppTasks;
using TaskManager.Application.Queries.GetSecurityGroups;

namespace TaskManager.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class AppTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAppTasks([FromQuery] GetAppTasksQuery tasksQuery)
        {
            var resp = await _mediator.Send(tasksQuery);
            return Ok(resp);

        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAppTask(AddAppTaskCommand task)
        {
            var resp = await _mediator.Send(task);
            return Ok(resp);

        }
    }
}
