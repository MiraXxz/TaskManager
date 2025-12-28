using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands.DeleteSecurityGroup
{
    public class DeleteSecurityGroupCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}
