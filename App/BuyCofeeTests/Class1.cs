using System;

namespace BuyCofeeTests
{
    using System.Threading.Tasks;

    using BuyCofeeTests.Common;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Xunit;

    public class APITest: BaseApiTest, IClassFixture<HostFixture>
    {
        public APITest(HostFixture host)
            : base(host)
        {
        }

        [Fact]
        public async Task InsertACoffeeBuilder()
        {

        }
    }

    public class TestStartup
    {
        public IConfiguration Config { get; }

        public TestStartup(IConfiguration config)
        {
            Config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            BuyCoffee.Startup.ConfigureServices(services);
            services.AddMvc()
                .AddModules()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.RegisterModulesServices();
            services.AddDatabases(Config.GetConnectionString("DefaultConnectionString"));
            services.AddCQSSupport();
        }

        public void Configure(IApplicationBuilder app)
        {
            var salesContext = app.ApplicationServices.GetService<SalesContext>();
            app.ApplyMigrations(salesContext);
            app.SeedDatabase(salesContext);
            

            Configuration.Configure(app, host => { return host; });
        }
    }
}
