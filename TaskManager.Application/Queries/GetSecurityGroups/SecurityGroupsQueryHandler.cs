using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetRoles;

namespace TaskManager.Application.Queries.GetSecurityGroups
{
    public class SecurityGroupsQueryHandler: IRequestHandler<SecurityGroupsQuery, SecurityGroupsResponse>
    {
        private readonly ISecurityGroupRepository _sgRepo;
        private readonly IMapper _mapper;
        public SecurityGroupsQueryHandler(ISecurityGroupRepository sgRepo, IMapper mapper)
        {
            _sgRepo = sgRepo;
            _mapper = mapper;
        }
        async Task<SecurityGroupsResponse> IRequestHandler<SecurityGroupsQuery, SecurityGroupsResponse>.Handle(SecurityGroupsQuery request, CancellationToken cancellationToken)
        {
            var sGroups = await _sgRepo.GetAllSecurityGroupsAsync();
            int count = sGroups.Count;
            sGroups = sGroups.Skip((request.pageNumber-1) * request.pageSize).Take(request.pageSize).ToList();

            var resp = new SecurityGroupsResponse();

            resp.listData = sGroups.Select(sg => _mapper.Map<SecurityGroupItem>(sg)).ToList(); ;
            foreach (var sg in resp.listData)
                sg.Roles = await _sgRepo.GetSecurityGroupRolesAsync(sg.Id);
           
            resp.rowsCount = count;
            
            return resp;
        }
    }
}
