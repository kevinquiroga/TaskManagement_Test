using System;
using MediatR;
using TaskManagement.Infraestructure.Persistence;
using static TaskManagement.Infraestructure.Commands.Commands;

namespace TaskManagement.Infraestructure.Handlers
{
	public class UpdateTaskCommandHandler: IRequestHandler<UpdateTaksCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTaksCommand command, CancellationToken cancellationToken)
        {
            var taskFind = await _dbContext.TaskPersistence.FindAsync(command.IdTask);

            if (taskFind == null)
            {
                // throw new NotFoundException("Tarea no encontrada");
            }

            taskFind.Name = command.Task.Name;
            taskFind.Description = command.Task.Description;
            taskFind.State = command.Task.State;
            taskFind.CreateDate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

