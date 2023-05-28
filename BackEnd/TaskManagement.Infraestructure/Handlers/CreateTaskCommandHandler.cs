using System;
using System.Threading;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Infraestructure.Persistence;
using static TaskManagement.Infraestructure.Commands.Commands;

namespace TaskManagement.Infraestructure.Handlers
{
	public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateTaskCommandHandler(ApplicationDbContext dbContext)
        { 
            _dbContext = dbContext;
		}

        public async Task<int> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
        {
            var NewTask = new TaskDTO
            {
                Name=command.Task.Name,
                Description=command.Task.Description,
                State=command.Task.State,
                CreateDate=command.Task.CreateDate
        
            };

            _dbContext.TaskPersistence.Add(NewTask);
            await _dbContext.SaveChangesAsync();

            return NewTask.IdTask;
        }
    }
}

