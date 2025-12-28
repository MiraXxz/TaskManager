using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Commands.AssignSecurityGroup
{
    internal class AssignSecurityGroupCommandHandler : IRequestHandler<AssignSecurityGroupCommand, AssignSecurityGroupResponse>
    {
        private readonly ISecurityGroupRepository _sgRepo;
        public AssignSecurityGroupCommandHandler(ISecurityGroupRepository sgRepo)
        {
            _sgRepo = sgRepo;
        }
        public async Task<AssignSecurityGroupResponse> Handle(AssignSecurityGroupCommand request, CancellationToken cancellationToken)
        {
            await _sgRepo.AssignSecurityGroupAsync(request.userId, request.SecurityGroupId, cancellationToken);

            return new AssignSecurityGroupResponse()
            {
                UserId = request.userId,
                SecurityGroupId = request.SecurityGroupId,
                Message = "Success"
                
            };
            
        }
    }
}
