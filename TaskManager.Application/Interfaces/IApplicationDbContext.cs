using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<SecurityGroup> SecurityGroups { get; set; }

        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
