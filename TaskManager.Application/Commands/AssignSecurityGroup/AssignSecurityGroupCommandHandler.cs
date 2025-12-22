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
        private readonly IUserRepository _userRepo;
        public AssignSecurityGroupCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<AssignSecurityGroupResponse> Handle(AssignSecurityGroupCommand request, CancellationToken cancellationToken)
        {
            await _userRepo.AssignSecurityGroupAsync(request.userId, request.SecurityGroupId, cancellationToken);

            return new AssignSecurityGroupResponse()
            {
                UserId = request.userId,
                SecurityGroupId = request.SecurityGroupId,
                Message = "Success"
                
            };
            
        }
    }
}
