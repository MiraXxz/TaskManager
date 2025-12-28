using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRolesAsync();

        Task<Role> AddRoleAsync(Role role, CancellationToken cancellationToken);

        Task<Role> UpdateRoleAsync(Role role, CancellationToken cancellationToken);

        Task DeleteRoleAsync(Role role, CancellationToken cancellationToken);
        Task<Role> GetRoleByIdAsync(int roleId);
    }
}
