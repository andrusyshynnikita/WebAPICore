using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebAPICore.BLL.Helpers;
using WebAPICore.BLL.Helpers.Interfaces;
using WebAPICore.BLL.Interfaces;
using WebAPICore.BLL.MapperProfiles;
using WebAPICore.BLL.Services;

namespace WebAPICore.BLL
{
    public static class Configuration
    {

        public static void Setup(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            services.AddAutoMapper(typeof(TaskProfile));
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IStorageHelper>(sp => new StorageHelper(hostingEnvironment.ContentRootPath));
        }
    }
}
