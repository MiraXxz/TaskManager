using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetRoles;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Infrastructure.Repositories
{
    public class SecurityGroupRepository: ISecurityGroupRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;
        public SecurityGroupRepository(IApplicationDbContext context, IMapper mapper, IRoleRepository roleRepo, IUserRepository userRepo)
        {
            _context = context;
            _mapper = mapper;
            _roleRepo = roleRepo;
        }

        public async Task<SecurityGroup> GetSecurityGroupById(int id)
        {
            SecurityGroup securityGroup = await _context.SecurityGroups.Include(sg => sg.SecurityGroupRoles).ThenInclude(sgr => sgr.Role).FirstOrDefaultAsync(sg => sg.Id == id);
            return securityGroup;
        }

        public async Task<List<SecurityGroup>> GetAllSecurityGroupsAsync()
        {
            var securityGroups = await _context.SecurityGroups.Include(sg => sg.SecurityGroupRoles).ThenInclude(sgr=>sgr.Role).ToListAsync();
            
            //SecurityGroup securityGroup = await _context.SecurityGroups.FirstOrDefaultAsync(sg => sg.Id == id);
            return securityGroups;
        }

        public async Task<List<RoleItem>> GetSecurityGroupRolesAsync(int id)
        {
            var sgWithRole = await _context.SecurityGroupRoles.Include(sgr => sgr.Role).Where(sgr => sgr.SecurityGroupId == id).Select(r=>_mapper.Map<RoleItem>(r.Role)).ToListAsync();
         
            return sgWithRole;
        }

        public async Task<SecurityGroup> AddSecurityGroupAsync(SecurityGroup sGroup, List<int> roles, CancellationToken cancellationToken)
        {
            string newGroupName = sGroup.GroupName;
            if (sGroup.Id > 0)
            {
                sGroup = await GetSecurityGroupById(sGroup.Id);
                sGroup.GroupName = newGroupName;

                var rolesToRemove = sGroup.SecurityGroupRoles.Where(sgr => !roles.Contains(sgr.RoleId)).ToList();
                foreach (var role in rolesToRemove)
                {
                    sGroup.SecurityGroupRoles.Remove(role);
                }                
            }
            else sGroup.SecurityGroupRoles = new List<SecurityGroupRole>();

            var existingRolesIds = sGroup.SecurityGroupRoles.Where(sgr => roles.Contains(sgr.RoleId)).Select(sgr=>sgr.RoleId).ToHashSet();

            foreach (var roleId in roles)
                if (await _roleRepo.GetRoleByIdAsync(roleId) != null && !existingRolesIds.Contains(roleId)) sGroup.SecurityGroupRoles.Add(new SecurityGroupRole { RoleId = roleId });
            

            if(sGroup.Id <= 0) await _context.SecurityGroups.AddAsync(sGroup);

            await _context.SaveChangesAsync(cancellationToken);
            return sGroup;

        }

        public async Task DeleteGroupAsync(int id, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Where(u => u.SecurityGroupId == id).Select(u=> u.Id).ToListAsync();
            foreach (var userId in users)
            {
                await AssignSecurityGroupAsync(userId, 2, cancellationToken);
            }
            var sGroup = await GetSecurityGroupById(id);
            if (sGroup != null)
            {
                _context.SecurityGroups.Remove(sGroup);
                _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AssignSecurityGroupAsync(int userId, int securityGroupId, CancellationToken cancellationToken)
        {
            SecurityGroup securityGroup = await GetSecurityGroupById(securityGroupId);
            if (securityGroup == null) throw new Exception("Security Group not found");

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new Exception("user does not exist");

            user.SecurityGroupId = securityGroupId;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
