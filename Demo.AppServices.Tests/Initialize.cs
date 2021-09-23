using AutoBogus;
using AutoBogus.Conventions;
using AutoBogus.Moq;
using Demo.AppServices.BizActions.Profiles;
using Demo.AppServices.Models.Profiles;
using Demo.AppServices.ProcessManagers;
using Demo.AppServices.QueryServices;
using Demo.Infras;
using Demo.Infras.Lite;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Demo.AppServices.Tests
{
    [TestClass]
    public class Initialize
    {
        internal static IServiceProvider Provider { get; private set; }

        [AssemblyInitialize]
        public static async Task AssemblyInitializeAsync(TestContext _)
        {
            AutoFaker.Configure(builder =>
            {
                builder.WithBinder(new MoqBinder());

                builder.WithConventions(c =>
                {
                    c.PhoneNumber.Aliases(nameof(ProfileModel.Phone));
                    c.JobTitle.Aliases(nameof(ProfileModel.Title));
                });
            });

            var service = new ServiceCollection()
                .AddDataKeyProvider<TestDataKeyProvider>()
                .AddLogging(c => c.AddDebug().AddConsole())
                .AddSingleton<IPrincipalProvider>(new TestPrincipalProvider())
                .AddAppServices()
                .AddInfraLite();

            service.AddBizRunner();

            Provider = service.BuildServiceProvider();

            await Provider.EnsureDbCreatedAsync().ConfigureAwait(false);
        }

        [TestMethod]
        public void Test_Setup()
        {
            Provider.GetService<IProfileQueryService>().Should().NotBeNull();
            Provider.GetService<IProfileSyncManager>().Should().NotBeNull();
            Provider.GetService<ICreateProfileAction>().Should().NotBeNull();
        }
    }
}
