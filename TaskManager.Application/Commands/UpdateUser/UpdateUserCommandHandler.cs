using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetUsers;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User {
                Id = request.Id,
                Username = request.Username,
                Email = request.Email,
                isActive = request.isActive,
                SecurityGroupId = request.SecurityGroupId
            };

            var result = await _userRepo.UpdateUserAsync(newUser, cancellationToken, request.Password);
            var resp = new UpdateUserResponse { User = _mapper.Map<UserItem>(result)};

            return resp;
        }
    }
}
