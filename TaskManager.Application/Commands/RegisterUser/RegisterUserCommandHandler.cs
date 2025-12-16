using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.RegisterUser
{
    internal class RegisterUserCommandHandler: IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepo; 
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public RegisterUserCommandHandler(ITokenService tokenService, IUserRepository userRepo, IMapper mapper, IPasswordService passwordService)
        {
            _tokenService = tokenService;
            _userRepo = userRepo;
            _mapper = mapper;
            _passwordService = passwordService;          
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            bool isExist = await _userRepo.IsExistByUsernameAsync(request.Username) || await _userRepo.IsExistByEmailAsync(request.Email);
            if (isExist) throw new Exception("User already exists");

            User newUser = _mapper.Map<User>(request);

            newUser.PasswordHash = _passwordService.HashPassword(request.Password);
            
            await _userRepo.AddUserAsync(newUser, cancellationToken);
            await _userRepo.AssignSecurityGroupAsync(newUser.Id, 2, cancellationToken);

            var roles = await _userRepo.GetUserSGRolesAsync(newUser);
            string token = _tokenService.CreateToken(newUser, roles);

            var resp = _mapper.Map<RegisterUserResponse>(newUser);
            resp.Token = token;

            return resp;

        }

    }
}
