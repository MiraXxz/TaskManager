using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Queries.GetAppTasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands.AddAppTask
{
    public class AddAppTaskCommandHandler : IRequestHandler<AddAppTaskCommand, AddAppTaskResponse>
    {
        private readonly IAppTaskRepository _taskRepo; 
        private readonly IMapper _mapper;
        public AddAppTaskCommandHandler(IAppTaskRepository taskRepo, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _mapper = mapper;
        }
        public async Task<AddAppTaskResponse> Handle(AddAppTaskCommand request, CancellationToken cancellationToken)
        {
            var addTask = new AppTask
            {
                Title = request.Title,
                Description = request.Description,
                TaskStatus = request.TaskStatus,
                UserId = request.UserId,
                IsDeleted = request.IsDeleted
            };

            if (request.Id > 0) addTask.Id = request.Id; 
            var addResult = await _taskRepo.AddAppTaskAsync(addTask, request.IsDeleted, cancellationToken);

            var resp = new AddAppTaskResponse();
            resp.AppTask = _mapper.Map<AppTaskItem>(addResult);
            return resp;

        }
    }
}
