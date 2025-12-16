using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands.LoginUser;
using TaskManager.Application.Commands.RegisterUser;

namespace TaskManager.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _mediator.Send(command);            
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(Exception e) {
                return Unauthorized();
            }
            
           
        }
    }
}
