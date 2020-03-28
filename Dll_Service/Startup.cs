using AutoMapper;
using Dll.Service.Config;
using Dll.Service.Extensions;
using Dll.Web.Cadastro.Extensions;
using KissLog;
using KissLog.Apis.v1.Auth;
using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dll_Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile(path: $"appsettings.{hostEnvironment.EnvironmentName }.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();  
            }

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseSetup(Configuration);
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.ResolveDependece();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LogFilters)); 

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddIdentitySetup();
            services.AddControllers();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapperSetup();
            services.AddDependencyInjectionSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseKissLogMiddleware(options => {
                options.Listeners.Add(new KissLogApiListener(new Application(
                    Configuration["KissLog.OrganizationId"],
                    Configuration["KissLog.ApplicationId"])
                ));
            }); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
