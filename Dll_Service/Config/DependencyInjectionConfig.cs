using KissLog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dll.Service.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependece(this IServiceCollection services)
        {
            services.AddScoped<ILogger>((context) =>  Logger.Factory.Get());

            return services;
        }
    }
}
