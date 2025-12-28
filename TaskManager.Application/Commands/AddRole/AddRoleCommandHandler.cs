using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, AddRoleCommandResponse>
    {
        public readonly IRoleRepository _roleRepo;
        public readonly IMapper _mapper; 
        public AddRoleCommandHandler(IRoleRepository roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public async Task<AddRoleCommandResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var addRole = new Role();
            addRole.RoleName = request.RoleName;
            if (request.RoleId != -1) addRole.Id = request.RoleId;
            
            var addRoleResult = await _roleRepo.AddRoleAsync(addRole, cancellationToken);
            var resp = new AddRoleCommandResponse();
            resp.RoleId = addRoleResult.Id;

            return resp;

        }
    }
}
