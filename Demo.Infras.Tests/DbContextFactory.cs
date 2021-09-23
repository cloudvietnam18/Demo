using Demo.Infras.Lite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infras.Tests
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<DemoContext>
    {
        #region Methods

        public DemoContext CreateDbContext(string[] args)
        {
            var service = new ServiceCollection()
                .AddInfraServices(Consts.ConnectionString)
                .AddDataKeyProvider<TestDataKeyProvider>()
                .AddLogging()
                .BuildServiceProvider();

            return service.GetRequiredService<DemoContext>();
        }

        #endregion Methods
    }
}
