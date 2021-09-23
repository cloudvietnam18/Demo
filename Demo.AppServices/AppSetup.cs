using Demo.Domains;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.AppServices.Tests")]

namespace Demo.AppServices
{
    public static class AppSetup
    {
        private const string Name = "Demo.AppServices";

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldUseConstructor = c => c.IsPublic;
                cfg.ShouldMapProperty = p => p.GetMethod?.IsPublic == true || p.CanRead;
            }, typeof(AppSetup).Assembly, typeof(DomainSchemas).Assembly);

            return services.Scan(s => s.FromAssemblies(typeof(AppSetup).Assembly)
                .AddClasses(c => c.InNamespaces($"{Name}.BizActions", $"{Name}.ProcessManagers", $"{Name}.QueryServices")).AsImplementedInterfaces()
                .WithScopedLifetime()
            );
        }
    }
}
