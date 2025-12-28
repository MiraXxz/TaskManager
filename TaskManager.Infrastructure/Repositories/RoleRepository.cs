using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IApplicationDbContext _context;
        public RoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> AddRoleAsync(Role role, CancellationToken cancellationToken)
        {
            var addRole = await GetRoleByIdAsync(role.Id);
            if (addRole != null)
                addRole.RoleName = role.RoleName;
            else  await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync(cancellationToken);
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role, CancellationToken cancellationToken)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);
            existingRole.RoleName = role.RoleName;
            await _context.SaveChangesAsync(cancellationToken);
            return role;
        }

        public async Task DeleteRoleAsync(Role role, CancellationToken cancellationToken)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }
    }
}
