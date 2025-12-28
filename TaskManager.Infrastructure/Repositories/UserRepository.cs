using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;
using TaskManager.Infrastructure.Service;

namespace TaskManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordService _passwordSrv;
        public UserRepository(IApplicationDbContext context, IPasswordService passwordSrv)
        {
            _context = context;
            _passwordSrv = passwordSrv;
        }

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user; 
        }

        public async Task<bool> IsExistByUsernameAsync(string username)
        {
            bool isExist = await _context.Users.AnyAsync(u => username == u.Username);
            return isExist;
        }

        public async Task<bool> IsExistByEmailAsync(string email)
        {
            bool isExist = await _context.Users.AnyAsync(u => email == u.Email);
            return isExist;
            throw new NotImplementedException();
        }

        public async Task<User> getUserByUsernameAsync(string username)
        {
            bool isExist = await IsExistByUsernameAsync(username);
            if (!isExist) throw new Exception("User does not exist");

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user; 

        }

        public async Task<User> GettUserByIdAsync(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<List<string>> GetUserSGRolesAsync(User user)
        {
            if (user.SecurityGroupId == null) return null;

            var securityGroup = await _context.SecurityGroups.Include(sg => sg.SecurityGroupRoles)
                .ThenInclude(sgr => sgr.Role)
                                .FirstAsync(sg => sg.Id == user.SecurityGroupId);

            var roles = securityGroup.SecurityGroupRoles.Where(x => x.SecurityGroupId == user.SecurityGroupId).Select(sgr => sgr.Role.RoleName).ToList();

            return roles;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users; 
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken, string? password = "")
        {

            var existingUser = await GettUserByIdAsync(user.Id);

            existingUser.Username = user.Username;
            existingUser.SecurityGroupId = user.SecurityGroupId;
            existingUser.isActive = user.isActive;

            existingUser.Email = user.Email;

            if(password!= null && password.Length > 0)existingUser.PasswordHash = _passwordSrv.HashPassword(password);

            await _context.SaveChangesAsync(cancellationToken);
            return existingUser;
        
        }
    }
}
