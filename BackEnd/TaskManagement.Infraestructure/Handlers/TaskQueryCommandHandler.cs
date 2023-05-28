using System;
using System.Collections.Generic;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Infraestructure.Persistence;
using static TaskManagement.Infraestructure.Commands.Commands;

namespace TaskManagement.Infraestructure.Handlers
{
	public class TaskQueryCommandHandler:IRequestHandler<TaskQueryCommand, TaskDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        public TaskQueryCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskDTO> Handle(TaskQueryCommand query, CancellationToken cancellationToken)
        {
            var taskFind = await _dbContext.TaskPersistence.FindAsync(query.IdTask);
            return taskFind;
        }
    }

    public class AllTaskQueryCommandHandler : IRequestHandler<AllTaskQueryCommand, List<TaskDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        public AllTaskQueryCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TaskDTO>> Handle(AllTaskQueryCommand query, CancellationToken cancellationToken)
        {
            var taskListFind = await _dbContext.TaskPersistence.ToListAsync();
            return taskListFind;
        }
    }
}

