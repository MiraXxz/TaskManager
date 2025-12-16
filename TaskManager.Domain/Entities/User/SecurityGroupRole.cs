using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities.User
{
    public class SecurityGroupRole
    {
        public int RoleId { get; set; }
        public int SecurityGroupId { get; set; }

        public Role Role { get; set; } = null;
        public SecurityGroup SecurityGroup { get; set; } = null;
    }
}
