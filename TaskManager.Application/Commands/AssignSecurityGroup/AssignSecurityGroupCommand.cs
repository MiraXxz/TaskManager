using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands.AssignSecurityGroup
{
    public class AssignSecurityGroupCommand: IRequest<AssignSecurityGroupResponse>
    {
        public int userId { get; set; }
        public int SecurityGroupId { get; set; }
    }
    
    public class AssignSecurityGroupResponse
    {
        public int UserId { get; set; }
        public int SecurityGroupId { get; set; }
        public string Message { get; set; } = null!;

    }
}
