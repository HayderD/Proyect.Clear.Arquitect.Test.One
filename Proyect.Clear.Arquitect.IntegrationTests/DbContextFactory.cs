using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Infrastructure;

namespace Proyect.Clear.Arquitect.IntegrationTests
{
    public static class DbContextFactory
    {
        public static AppDbContext CreateInMemorySqliteDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new AppDbContext(options);

            context.Database.OpenConnection();   // Requerido para SQLite in-memory
            context.Database.EnsureCreated();    // Aplica el esquema (migraciones no necesarias)

            return context;
        }
    }
}
