using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities.User
{
    public class SecurityGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<SecurityGroupRole> SecurityGroupRoles { get; set; } = new List<SecurityGroupRole>();
    }
}
