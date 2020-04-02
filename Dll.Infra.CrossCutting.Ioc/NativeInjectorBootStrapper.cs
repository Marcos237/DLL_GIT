using Dll.Application.Interfaces;
using Dll.Application.Service;
using Dll.Domain.Interfaces;
using Dll.Domain.Interfaces.Repository;
using Dll.Domain.Interfaces.Services;
using Dll.Domain.Services;
using Dll.Infra.Data.Interface;
using Dll.Infra.Data.Repository;
using Dll.Infra.Data.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Dll.Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //Identity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //AppService
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioLogadoAppService, UsuarioLogadoLogAppService>();


            //Dominio

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioLogadoLogService, UsuarioLogadoLogService>();


            //Infra Dados
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUserRepository, AspNetUsersRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Serviço


        }
    }
}