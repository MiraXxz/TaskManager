using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.AddRole;
using TaskManager.Application.Commands.AddSecurityGroup;
using TaskManager.Application.Commands.AssignSecurityGroup;
using TaskManager.Application.Commands.DeleteSecurityGroup;
using TaskManager.Application.Commands.UpdateUser;
using TaskManager.Application.Queries.GetRoles;
using TaskManager.Application.Queries.GetSecurityGroups;
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
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery usersQuery)
        {
            var users = await _mediator.Send(usersQuery);

            return Ok(users);
        }

        [HttpPost("securityGroups/assign")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignSecurityGroup(AssignSecurityGroupCommand assignRequest)
        {
            var resp = await _mediator.Send(assignRequest);
            return Ok(resp);

        }

        [HttpGet("roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQuery rolesQuery)
        {
            var resp = await _mediator.Send(rolesQuery);
            return Ok(resp);

        }

        [HttpPost("roles")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(AddRoleCommand role)
        {
            var resp = await _mediator.Send(role);
            return Ok(resp);

        }

        [HttpGet("securityGroups")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSecurityGroups([FromQuery]SecurityGroupsQuery sgQuery)
        {
            var resp = await _mediator.Send(sgQuery);
            return Ok(resp);

        }

        [HttpPost("securityGroups")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSecurityGroup(AddSecurityGroupCommand sGroup)
        {
            var resp = await _mediator.Send(sGroup);
            return Ok(resp);

        }

        [HttpDelete("securityGroups/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSecurityGroup([FromRoute] int id)
        {
            var command = new DeleteSecurityGroupCommand { Id = id };
            var resp = await _mediator.Send(command);
            return Ok(resp);

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand user)
        {
            var resp = await _mediator.Send(user);
            return Ok(resp);

        }


    }
}
