using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Application.Queries.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, GetRolesQueryResponse>
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IMapper _mapper;
        public GetRolesQueryHandler(IRoleRepository roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public async Task<GetRolesQueryResponse> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepo.GetRolesAsync();
            int count = roles.Count;

            if (request.pageNumber > 0 && request.pageSize > 0)
            {
                int skip = (request.pageNumber - 1) * request.pageSize;
                roles = roles.Skip(skip).Take(request.pageSize).ToList();
            }

            var resp = new GetRolesQueryResponse();
            resp.listData = roles.ToList().Select(r => _mapper.Map<RoleItem>(r)).ToList();
            resp.rowsCount = count;

            return resp;
        }
    }
}
