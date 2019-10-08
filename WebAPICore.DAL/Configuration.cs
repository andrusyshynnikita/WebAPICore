using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPICore.DAL.Interfaces;
using WebAPICore.DAL.Repositories;

namespace WebAPICore.DAL
{
    public static class Configuration
    {

        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
