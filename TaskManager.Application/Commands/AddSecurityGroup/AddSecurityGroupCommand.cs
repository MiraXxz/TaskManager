using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Queries.GetSecurityGroups;

namespace TaskManager.Application.Commands.AddSecurityGroup
{
    public class AddSecurityGroupCommand : IRequest<AddSecurityGroupResponse>
    {
        public int Id { get; set; } = -1;
        public string GroupName { get; set; }
        public List<int> RoleIds { get; set; } = [];
    }
    public class AddSecurityGroupResponse
    {
        public int EntityId { get; set; }
        public SecurityGroupItem SecurityGroup {get; set;}

    }
}
