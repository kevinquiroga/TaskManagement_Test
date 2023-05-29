using System;
using System.Reflection;
using System.Threading;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Commands
{
   
    public class Commands
	{

        
        public class CreateTaskCommand : IRequest<int>
        {
            public TaskDTO Task { get; set; }
       
        }
        public class UpdateTaksCommand : IRequest
        {
            public int IdTask { get; set; }
            public TaskDTO Task { get; set; }
 
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

