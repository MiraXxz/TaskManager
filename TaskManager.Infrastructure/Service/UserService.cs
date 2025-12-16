using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Infrastructure.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ISecurityGroupRepository _sgRepo;
        public UserService(IUserRepository userRepo, ISecurityGroupRepository sgRepo)
        {
            _userRepo = userRepo;     
            _sgRepo = sgRepo;
        }

        
    }
}
