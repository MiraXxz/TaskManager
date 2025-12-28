using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Domain.Entities
{
    public class AppTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskStatus { get; set; }
        public int? UserId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public User.User User { get; set; }
    }
}
