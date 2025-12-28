using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetUsers;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Queries.GetRoles
{
    public class GetRolesQuery: IRequest<GetRolesQueryResponse>
    {
        public int pageSize { get; set; } = 5;
        public int pageNumber { get; set; } = 1;
    }

    public class GetRolesQueryResponse
    {
        public List<RoleItem> listData = [];
        public int rowsCount = 0;
    }
    public class RoleItem
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
