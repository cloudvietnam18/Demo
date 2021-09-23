using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Api.Handlers
{
    public sealed class HealthCheck : IHealthCheck
    {
        #region Fields

        private readonly ILogger<HealthCheck> logger;

        #endregion Fields

        #region Constructors

        public HealthCheck(ILogger<HealthCheck> logger)
        {
            this.logger = logger;
        }

        #endregion Constructors

        #region Methods

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                var goodms = "Demo Services is in GOOD health";
                logger.LogInformation(goodms);

                return Task.FromResult(
                    HealthCheckResult.Healthy(goodms));
            }

            var ms = "Demo Services is in BAD health";
            logger.LogInformation(ms);

            return Task.FromResult(
                HealthCheckResult.Unhealthy(ms));
        }

        #endregion Methods
    }
}
