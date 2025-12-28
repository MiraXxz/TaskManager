using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Queries.GetUsers
{
    public class GetUsersQuery: IRequest<GetUsersRepsonse>
    {
        public int pageSize { get; set; } = 5;
        public int pageNumber { get; set; } = 1;
    }

    public class GetUsersRepsonse
    {
        public List<UserItem> listData = [];
        public int rowsCount = 0;
    }

    public class UserItem
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool? isActive { get; set; } = false;
        public int? SecurityGroupId { get; set; } = null;
    }
}
