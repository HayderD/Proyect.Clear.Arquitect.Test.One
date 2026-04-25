using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Application.UseCases;
using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Infrastructure.Service;

namespace Proyect.Clear.Arquitect.IntegrationTests.Tests
{
    public class RegisterUserIntegrationSqlServerTests
    {
        //[Fact]
        //[Trait("Category", "SQLServer")]
        //public async Task Should_Store_Real_User_In_SQL_Server()
        //{
        //    //var enabled = Environment.GetEnvironmentVariable("ENABLE_SQLSERVER_TESTS");
        //    //if (enabled != "true")
        //    //{
        //    //    return; // salta la prueba
        //    //}

        //    using var context = DbContextSqlServerFactory.CreateSqlServerDbContext();
        //    var repo = new EfProductRepository(context);
        //    var useCase = new RegisterUserUseCase(repo);

        //    var request = new ProductRequest
        //    {
        //        Name = "Prueba SQL Server",
        //        Email = "sqltest@example.com"
        //    };

        //    var result = await useCase.ExecuteAsync(request);

        //    Assert.Equal("Usuario registrado.", result);

        //    var userInDb = await context.Users.FirstOrDefaultAsync(u => u.Email == "sqltest@example.com");
        //    Assert.NotNull(userInDb);
        //}

        //[Fact]
        //[Trait("Category", "SQLServer")]
        //public async Task Should_Not_Register_User_When_Email_Already_Exists_In_SQL_Server()
        //{
        //    //var enabled = Environment.GetEnvironmentVariable("ENABLE_SQLSERVER_TESTS");
        //    //if (enabled != "true") return;

        //    using var context = DbContextSqlServerFactory.CreateSqlServerDbContext();

        //    // 🔄 Asegurarse que no exista el usuario antes
        //    var existing = await context.Users.FirstOrDefaultAsync(u => u.Email == "yaexiste@example.com");
        //    if (existing != null)
        //    {
        //        context.Users.Remove(existing);
        //        await context.SaveChangesAsync();
        //    }

        //    // 🔹 Insertar usuario con el correo
        //    await context.Users.AddAsync(new User { Name = "Primero", Email = "yaexiste@example.com" });
        //    await context.SaveChangesAsync();

        //    // 🔹 Preparar caso de uso
        //    var repo = new EfProductRepository(context);
        //    var useCase = new RegisterUserUseCase(repo);

        //    var request = new ProductRequest
        //    {
        //        Name = "Segundo",
        //        Email = "yaexiste@example.com" // ya en la BD
        //    };

        //    // 🔸 Ejecutar
        //    var result = await useCase.ExecuteAsync(request);

        //    // ✅ Verificar que el sistema lo rechaza
        //    Assert.Equal("El correo ya existe.", result);
        //}

    }
}
