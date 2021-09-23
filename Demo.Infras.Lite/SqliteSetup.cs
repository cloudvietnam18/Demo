using Demo.Infras;
using Demo.Infras.Lite;
using System;
using System.Threading.Tasks;

// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SqliteSetup
    {
        #region Methods

        public static IServiceCollection AddInfraLite(this IServiceCollection service)
        {
            service
                .AddGenericRepositories<DemoContext>()
                .AddImplementations()
                .AddBoundedContext<DemoContext>(op => op.UseSqliteMemory());
            return service;
        }

        public static async Task EnsureDbCreatedAsync(this IServiceProvider serviceProvider) => await serviceProvider.GetRequiredService<DemoContext>().Database.EnsureCreatedAsync().ConfigureAwait(false);

        public static async Task EnsureDbDeletedAsync(this IServiceProvider serviceProvider) => await serviceProvider.GetRequiredService<DemoContext>().Database.EnsureDeletedAsync().ConfigureAwait(false);

        #endregion Methods
    }
}
