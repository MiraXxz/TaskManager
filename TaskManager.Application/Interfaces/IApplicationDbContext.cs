using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<SecurityGroup> SecurityGroups { get; set; }
        public DbSet<SecurityGroupRole> SecurityGroupRoles { get; set; }

        public DbSet<AppTask> AppTasks { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
