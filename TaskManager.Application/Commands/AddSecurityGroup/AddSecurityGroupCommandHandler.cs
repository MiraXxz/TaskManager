using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetSecurityGroups;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Commands.AddSecurityGroup
{
    public class AddSecurityGroupCommandHandler : IRequestHandler<AddSecurityGroupCommand, AddSecurityGroupResponse>
    {
        private readonly ISecurityGroupRepository _sgRepo;
        private readonly IMapper _mapper;
        public AddSecurityGroupCommandHandler(ISecurityGroupRepository sgRepo, IMapper mapper)
        {
            _sgRepo = sgRepo;
            _mapper = mapper;
        }
        public async Task<AddSecurityGroupResponse> Handle(AddSecurityGroupCommand request, CancellationToken cancellationToken)
        {
            SecurityGroup sGroup = new SecurityGroup();
            if(request.Id != -1) sGroup.Id = request.Id;
            sGroup.GroupName = request.GroupName;

            var addResult = await _sgRepo.AddSecurityGroupAsync(sGroup, request.RoleIds, cancellationToken);
            var resp = new AddSecurityGroupResponse();
            resp.SecurityGroup = _mapper.Map<SecurityGroupItem>(addResult);
            resp.EntityId = addResult.Id;

            return resp;
                
        }
    }
}
