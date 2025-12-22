using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.AssignSecurityGroup;
using TaskManager.Application.Queries.GetUsers;

namespace TaskManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers([FromQuery]GetUsersQuery usersQuery)
        {
            var users = await _mediator.Send(usersQuery);

            return Ok(users);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignSecurityGroup(AssignSecurityGroupCommand assignRequest)
        {
            var resp = await _mediator.Send(assignRequest);
            return Ok(resp);

        }
    }
}
