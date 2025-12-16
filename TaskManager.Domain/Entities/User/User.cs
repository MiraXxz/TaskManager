using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool? isActive { get; set; } = false;
        public int? SecurityGroupId { get; set; } = null;
        public SecurityGroup? SecurityGroup { get; set; } = null;

    }
}
