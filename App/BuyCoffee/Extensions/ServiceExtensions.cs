using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyCoffee.Extensions
{
    using BuyCoffee.Models;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Builder.Internal;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoffeeBuyersContext>(
               options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
               //options => options.UseInMemoryDatabase("lol"));
            return services;

        }

        public static void MigrateDatabase(this IApplicationBuilder builder, CoffeeBuyersContext context)
        {
            context.Database.Migrate();
        }
    }
}
