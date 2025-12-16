using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskManager.Application.Commands.LoginUser;
using TaskManager.Application.Commands.RegisterUser;
using TaskManager.Application.Queries.GetUsers;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserCommand, User>();
            CreateMap<User, RegisterUserResponse>();

            CreateMap<LoginUserCommand, User>();
            CreateMap<User, LoginUserResponse>();

            CreateMap<User, GetUserResponse>();
        }
    }
}
