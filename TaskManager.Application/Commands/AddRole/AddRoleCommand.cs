using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands.AddRole
{
    public class AddRoleCommand: IRequest<AddRoleCommandResponse>
    {
        public int RoleId { get; set; } = -1;
        public string RoleName { get; set; }
    }
    
    public class AddRoleCommandResponse
    {
        public int RoleId { get; set; }

    }
}
