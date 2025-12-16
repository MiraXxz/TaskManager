using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Infrastructure.Repositories
{
    public class SecurityGroupRepository: ISecurityGroupRepository
    {
        private readonly IApplicationDbContext _context;
        public SecurityGroupRepository(IApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<SecurityGroup> GetSecurityGroupById(int id)
        {
            SecurityGroup securityGroup = await _context.SecurityGroups.FirstOrDefaultAsync(sg => sg.Id == id);
            return securityGroup;
        }
    }
}
