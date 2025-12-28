using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Queries.GetAppTasks
{
    public class GetAppTasksQuery:IRequest<GetAppTasksResponse>
    {
        public int pageSize { get; set; } = 5;
        public int pageNumber { get; set; } = 1;
    }
    public class GetAppTasksResponse
    {
        public List<AppTaskItem> listData { get; set; }
        public int count { get; set; }

    }
    public class AppTaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskStatus { get; set; }
        public int? UserId { get; set; }

        public TaskUserItem User { get; set; }
    }

    public class TaskUserItem
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool? isActive { get; set; } = false;
    }
}
