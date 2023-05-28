using MediatR;
using TaskManagement.Infraestructure.Persistence;
using static TaskManagement.Application.Commands.Commands;

namespace TaskManagement.Infraestructure.Handlers
{
	public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteTaskCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
        {
            var taskFind = await _dbContext.TaskPersistence.FindAsync(command.IdTask);

            if (taskFind == null)
            {
                // throw new NotFoundException("Tarea no encontrada");
            }

            _dbContext.TaskPersistence.Remove(taskFind);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }

      
    }
}

