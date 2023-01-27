using GCP.DAL.UoW;
using GCP.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCP.BLL.Interfaces;
using GCP.BLL.Realizations;

namespace GCP.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(
           this IServiceCollection services
           )
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
