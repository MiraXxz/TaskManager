using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Queries.GetAppTasks;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.AddAppTask
{
    public class AddAppTaskCommand:IRequest<AddAppTaskResponse>
    {
        public int Id { get; set; } = -1;
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int TaskStatus { get; set; }
        public int? UserId { get; set; }

        public bool IsDeleted { get; set; } = false; 
    }
    public class AddAppTaskResponse
    {
        public AppTaskItem AppTask { get; set; }

    }
}
