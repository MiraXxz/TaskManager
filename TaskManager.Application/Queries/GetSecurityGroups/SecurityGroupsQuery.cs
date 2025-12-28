using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Queries.GetRoles;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Queries.GetSecurityGroups
{
    public class SecurityGroupsQuery: IRequest<SecurityGroupsResponse>
    {
        public int pageSize { get; set; } = 5;
        public int pageNumber { get; set; } = 1;
    }
    public class SecurityGroupsResponse
    {
        public List<SecurityGroupItem> listData { get; set; } = [];
        public int rowsCount { get; set; } = 0;
    }
    public class SecurityGroupItem
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<RoleItem>? Roles { get; set; }
    }
}
