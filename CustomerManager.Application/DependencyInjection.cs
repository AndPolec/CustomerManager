using CustomerManager.Application.Interfaces;
using CustomerManager.Application.Mappers;
using CustomerManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerMapper, CustomerMapper>();
            return services;
        }
    }
}
