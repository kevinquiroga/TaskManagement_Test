using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Commands;
using TaskManagement.Domain.Entities;
using TaskManagement.Infraestructure.Handlers;
using TaskManagement.Infraestructure.Persistence;
using static TaskManagement.Application.Commands.Commands;

namespace TaskManagement.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


          

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=tcp:sqlserver12.database.windows.net,1433;Initial Catalog=TaskManagement;Persist Security Info=False;User ID=kaquiroga;Password=Espe2023.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddMediatR(typeof(Commands));
            services.AddScoped<IRequestHandler<CreateTaskCommand, int>, CreateTaskCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteTaskCommand,Unit>, DeleteTaskCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTaksCommand,Unit>, UpdateTaskCommandHandler>();
            services.AddScoped<IRequestHandler<TaskQueryCommand, TaskDTO>, TaskQueryCommandHandler>();
            services.AddScoped<IRequestHandler<AllTaskQueryCommand, List<TaskDTO>>, AllTaskQueryCommandHandler>();

            return services;
        }

    }
}

