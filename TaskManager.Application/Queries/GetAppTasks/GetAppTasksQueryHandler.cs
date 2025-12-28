using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;

namespace TaskManager.Application.Queries.GetAppTasks
{
    public class GetAppTasksQueryHandler : IRequestHandler<GetAppTasksQuery, GetAppTasksResponse>
    {
        private readonly IAppTaskRepository _taskRepo;
        private readonly IMapper _mapper;
        public GetAppTasksQueryHandler(IAppTaskRepository taskRepo, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _mapper = mapper;
        }
        public async Task<GetAppTasksResponse> Handle(GetAppTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepo.GetAppTasksAsync();
            
            var resp = new GetAppTasksResponse();
            resp.listData = tasks.Select(t=>_mapper.Map<AppTaskItem>(t)).ToList(); 
            resp.count = tasks.Count;
            return resp;
        }
    }
}
