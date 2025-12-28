using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Queries.GetRoles;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Interfaces
{
    public interface ISecurityGroupRepository
    {
        Task<SecurityGroup> GetSecurityGroupById(int id);
        Task<List<SecurityGroup>> GetAllSecurityGroupsAsync();
        Task<SecurityGroup> AddSecurityGroupAsync(SecurityGroup sGroup, List<int> roles, CancellationToken cancellationToken);
        Task<List<RoleItem>> GetSecurityGroupRolesAsync(int id);

        Task DeleteGroupAsync(int id, CancellationToken cancellationToken);
        Task AssignSecurityGroupAsync(int userId, int securityGroupId, CancellationToken cancellationToken);
    }

}
