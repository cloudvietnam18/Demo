using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Demo.Infras
{
    public static class InfraMigration
    {
        public static async Task MigrateDb(string connectionString)
        {
            //Db migration
            await using var db = new DemoContext(new DbContextOptionsBuilder()
                .UseSqlWithMigration(connectionString)
                .UseAutoConfigModel()
                .Options, null);

            await db.Database.MigrateAsync().ConfigureAwait(false);
        }
    }
}
