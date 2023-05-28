using System;
using System.Threading;
using MediatR;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infraestructure.Commands
{
	public class Commands
	{
        public class CreateTaskCommand : IRequest<int>
        {
            public TaskDTO Task { get; set; }
            //public string Name { get; set; }
            //public string Description { get; set; }
            //public StateTask State { get; set; }
            //public DateTime CreateDate { get; set; }
        }
        public class UpdateTaksCommand : IRequest
        {
            public int IdTask { get; set; }
            public TaskDTO Task { get; set; }
            //public int IdTask { get; set; }
            //public string Name { get; set; }
            //public string Description { get; set; }
            //public StateTask State { get; set; }
            //public DateTime CreateDate { get; set; }
        }
        public class DeleteTaskCommand : IRequest
        {
            public int IdTask { get; set; }
        }
        public class TaskQueryCommand : IRequest<TaskDTO>
        {
            public int IdTask { get; set; }
        }

        public class AllTaskQueryCommand : IRequest<List<TaskDTO>>
        {
        }

    }
}

