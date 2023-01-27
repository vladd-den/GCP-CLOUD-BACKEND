using GCP.DAL.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.DAL.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(
           this IServiceCollection services
           )
        {
            services.AddSingleton<IConnectionStringResolver, ConnectionStringResolver>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }
    }
}
