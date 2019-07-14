using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigital.PhoneBook.Service
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoneBookServices(this IServiceCollection services)
        {
            services.AddTransient<IPhoneBookService, PhoneBookService>();
            return services;
        }
    }
}
