using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Interfaces
{
    public interface IAppTaskRepository
    {
        Task<List<AppTask>> GetAppTasksAsync();
        Task<AppTask> AddAppTaskAsync(AppTask task, bool isDelete, CancellationToken cancellationToken);


        //Task<AppTask> AddAppTaskAsync(AppTask task, CancellationToken cancellationToken);

        //Task<AppTask> UpdateRoleAsync(AppTask task, CancellationToken cancellationToken);

        //Task DeleteRoleAsync(AppTask task, CancellationToken cancellationToken);
        //Task<AppTask> GetRoleByIdAsync(int taskId);
    }
}
