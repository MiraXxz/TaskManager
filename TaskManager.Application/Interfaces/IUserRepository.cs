using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsExistByUsernameAsync(string username);
        Task<bool> IsExistByEmailAsync(string email);
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User> getUserByUsernameAsync(string username);
        Task<User> GettUserByIdAsync(int id);

        Task AssignSecurityGroupAsync(int userId, int securityGroupId, CancellationToken cancellationToken);

        Task<List<string>> GetUserSGRolesAsync(User user);
        Task<List<User>> GetUsersAsync();
    }
}
