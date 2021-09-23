using Demo.AppServices;
using Demo.Domains;
using Demo.Infras.EventHandlers;
using HBD.EfCore.BizAction.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.AppServices.Tests")]
[assembly: InternalsVisibleTo("Demo.Infra.Tests")]

namespace Demo.Infras
{
    public static class InfraSetup
    {
        private const string Name = "Demo.Infras";

        public static IServiceCollection AddInfraServices(this IServiceCollection service, string connectionString)
        {
            service
                .AddGenericRepositories<DemoContext>()
                .AddImplementations()
                .AddCoreInfraServices<DemoContext>(op =>
                    {
                        op.UseSqlWithMigration(connectionString);

#if DEBUG
                        op.EnableDetailedErrors().EnableSensitiveDataLogging();
#else
                        //TODO: Workaround solution to ignored the Too many IServiceProvider created exception;
                        op.ConfigureWarnings(x => x.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));
#endif
                    },
                    enableAutoMapper: false,
                    enableAutoScanEventHandler: true,
                    assembliesToScans: new[] { typeof(InfraSetup).Assembly, typeof(DomainSchemas).Assembly });

            return service.AddBizRunner();
        }

        internal static IServiceCollection AddBizRunner(this IServiceCollection services)
        {
            services.RegisterBizRunner<DemoContext>(new GenericBizRunnerConfig
            {
                DoNotValidateSaveChanges = true,
                SaveChangesExceptionHandler = SaveChangesExceptionHandler.Handler
            });

            return services;
        }

        internal static IServiceCollection AddImplementations(this IServiceCollection services)
        {
            services.AddEventPublisher<EventPublisher>();

            return services.Scan(s => s.FromAssemblies(typeof(InfraSetup).Assembly)
                .AddClasses(c => c.InNamespaces($"{Name}.Repos", $"{Name}.Services", $"{Name}.EventHandlers")).AsImplementedInterfaces().WithScopedLifetime());
        }
    }
}
