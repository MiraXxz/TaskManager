using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities.User
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<SecurityGroupRole> SecurityGroupRoles { get; set; } = new List<SecurityGroupRole>();
        
    }
}
