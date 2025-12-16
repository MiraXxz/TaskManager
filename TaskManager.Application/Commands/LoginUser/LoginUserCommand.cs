using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }

    public class LoginUserResponse{
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
