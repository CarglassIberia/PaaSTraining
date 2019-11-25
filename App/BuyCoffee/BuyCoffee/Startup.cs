namespace BuyCoffee
{
    using System.Linq;

    using BuyCoffee.Extensions;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("DevPolicy", b => { b.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); });
            });

            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();
                setup.DescribeStringEnumsInCamelCase();
                setup.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "Coffee Buyers",
                    Version = "v1"
                });
            });

            services.AddDatabase(Configuration);
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CoffeeBuyersContext context)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger().UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Coffee Buyers");
            });

            app.MigrateDatabase(context);
            app.UseHttpsRedirection();
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Default}/{action=Swagger}"); });
        }
    }
}