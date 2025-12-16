using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.LoginUser
{
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService; 
        private readonly IMapper _mapper;
        public LoginUserCommandHandler(IPasswordService passwordService, IUserRepository userRepo, ITokenService tokenService, IMapper mapper)
        {
            _passwordService = passwordService;
            _userRepo = userRepo;   
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepo.getUserByUsernameAsync(request.Username);

            if (!_passwordService.VerifyPassword(user.PasswordHash,request.Password))
            {
                throw new Exception("Username or password are incorrect.");
            }
            var roles = await _userRepo.GetUserSGRolesAsync(user);

            var resp = _mapper.Map<LoginUserResponse>(user);
            resp.Token = _tokenService.CreateToken(user, roles);

            return resp;
        }
    }
}
