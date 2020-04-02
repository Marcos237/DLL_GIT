using Dll.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dll.Web.Cadastro.Extensions
{
    public static class IdentitySetup
    {
        public static void AddIdentitySetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Configurações de senha  
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                //EmailUnico
                options.User.RequireUniqueEmail = true;
            });
        }

        public static void AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
        {
            //if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddAuthentication()
            //    .AddFacebook(o =>
            //    {
            //        o.AppId = configuration["Authentication:Facebook:AppId"];
            //        o.AppSecret = configuration["Authentication:Facebook:AppSecret"];
            //    })
            //    .AddGoogle(googleOptions =>
            //    {
            //        googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
            //        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            //    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
            //    options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
            //});
        }
    }
}