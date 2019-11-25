namespace BuyCofeeTests.Common
{
    using BuyCoffee.Models;
    using FluentAssertions.Common;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class HostFixture
    {
        public readonly TestServer WebApi;
        public IConfigurationRoot Configuration;

        private CoffeeBuyersContext PrepareContext() 
        {
            var cnnString = Configuration.GetSection("ConnectionStrings:DefaultConnectionString").Value;

            
            var context = new CoffeeBuyersContext(new DbContextOptionsBuilder().UseSqlServer(cnnString).Options);
            context.Database.Migrate();
            return context;
        }

        public HostFixture() : base()
        {
            WebApi = new TestServer(
                new WebHostBuilder()
                    .UseConfiguration(Configuration)
                    .ConfigureServices(services =>
                        {
                            //Aqui tu Configuracion Por defecto
                        })
                    .UseStartup<TestStartup>()
            );
        }
    }
}