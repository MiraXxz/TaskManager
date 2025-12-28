using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Commands.DeleteSecurityGroup
{
    public class DeleteSecurityGroupCommandHandler : IRequestHandler<DeleteSecurityGroupCommand, bool>
    {
        private readonly ISecurityGroupRepository _sgRepo;
        public DeleteSecurityGroupCommandHandler(ISecurityGroupRepository sgRepo)
        {
            _sgRepo = sgRepo;
        }
        public async Task<bool> Handle(DeleteSecurityGroupCommand request, CancellationToken cancellationToken)
        {
            await _sgRepo.DeleteGroupAsync(request.Id, cancellationToken);
            return true;
        }
    }
}
