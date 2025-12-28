using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly IApplicationDbContext _context;
        public AppTaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AppTask>> GetAppTasksAsync()
        {
            var tasks = await _context.AppTasks.Include(t=>t.User).Where(t=> !t.IsDeleted).ToListAsync();
            return tasks; 
        }

        public async Task<AppTask> AddAppTaskAsync(AppTask task, bool isDelete, CancellationToken cancellationToken)
        {
            var addTask = task;
            if (task.Id != -1)
            {
                addTask = await _context.AppTasks.Include(t=>t.User).FirstOrDefaultAsync();

                addTask.Title = task.Title;
                addTask.Description = task.Description;
                addTask.TaskStatus = task.TaskStatus;
                addTask.UserId = task.UserId;
                addTask.IsDeleted = isDelete;
            }
            else await _context.AppTasks.AddAsync(addTask);
            addTask.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == addTask.UserId);

            await _context.SaveChangesAsync(cancellationToken);
            return addTask;
        }
    }
}
