using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Queries.GetUsers;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.UpdateUser
{
    public class UpdateUserCommand:IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool? isActive { get; set; } = false;
        public int? SecurityGroupId { get; set; } = null;
    }
    public class UpdateUserResponse
    {
        public UserItem User { get; set; }

    }
}
