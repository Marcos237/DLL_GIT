using Dll.Infra.CorssCutting.Identity.Models;
using Dll.Infra.Data;
using Dll.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Dll.Web.Cadastro.Extensions
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UsuarioDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
