using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Interfaces
{
    public interface ISecurityGroupRepository
    {
        Task<SecurityGroup> GetSecurityGroupById(int id);
    }

}
