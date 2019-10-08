using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPICore.BLL.Helpers;
using WebAPICore.BLL.Helpers.Interfaces;
using WebAPICore.BLL.Interfaces;
using WebAPICore.BLL.MapperProfiles;
using WebAPICore.BLL.Services;
using WebAPICore.DAL;
using WebAPICore.DAL.Interfaces;
using WebAPICore.DAL.Repositories;

namespace WeAPICore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContextPool<WebAPICoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalDataBase")));

            WebAPICore.BLL.Configuration.Setup(services, HostingEnvironment);
            WebAPICore.DAL.Configuration.Setup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
