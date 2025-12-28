using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersRepsonse>
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper; 
        public GetUsersQueryHandler(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            
        }
        public async Task<GetUsersRepsonse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetUsersAsync();
            int count = users.Count();
            
            if(request.pageNumber > 0 && request.pageSize > 0)
            {
                int skip = (request.pageNumber - 1) * request.pageSize;
                users = users.Skip(skip).Take(request.pageSize).ToList();
            }

            var respUsers = users.ToList().Select(u => _mapper.Map<UserItem>(u)).ToList();
            GetUsersRepsonse resp = new GetUsersRepsonse();
            resp.listData = respUsers;
            resp.rowsCount = count; 

            return resp;
        }
    }
}
