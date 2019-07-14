using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigital.PhoneBook.Component
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoneBookComponents(this IServiceCollection services)
        {
            services.AddTransient<IPhoneBookComponent, PhoneBookComponent>();
            services.AddTransient<ISqlRepository, SqlRepository>();
            return services;
        }
    }
}
