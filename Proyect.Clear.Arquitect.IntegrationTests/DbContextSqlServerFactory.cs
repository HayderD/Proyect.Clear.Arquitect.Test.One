using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Infrastructure;

namespace Proyect.Clear.Arquitect.IntegrationTests
{
    public class DbContextSqlServerFactory
    {
        public static AppDbContext CreateSqlServerDbContext()
        {
            var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_TEST_CONNECTION")
                ?? "Server=DESKTOP-C04R277\\SQLEXPRESS;Database=MyCleanDb;Trusted_Connection=True;TrustServerCertificate=True;";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }

}
