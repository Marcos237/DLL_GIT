using AutoMapper;
using Dll.Application.AutoMapper;
using Dll_Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dll.Service.Extensions
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(EntityToViewModelMapper), typeof(ViewModelToEntityMapper));
        }
    }
}
