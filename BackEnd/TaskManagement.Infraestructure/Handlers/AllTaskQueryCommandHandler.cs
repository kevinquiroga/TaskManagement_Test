using System;
using MediatR;
using static TaskManagement.Application.Commands.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infraestructure.Handlers
{

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

