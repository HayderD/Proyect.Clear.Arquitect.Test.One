using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Application.UseCases;
using Proyect.Clear.Arquitect.Infrastructure.Service;

namespace Proyect.Clear.Arquitect.IntegrationTests.Tests;

public class RegisterUserIntegrationTests
{
    //[Fact]
    //public async Task Should_Register_User_Into_Real_Database()
    //{
    //    // Arrange
    //    using var context = DbContextFactory.CreateInMemorySqliteDbContext();
    //    var efRepo = new EfProductRepository(context);
    //    var useCase = new ProductUseCase(efRepo);

    //    var request = new ProductRequest
    //    {
    //        Name = "Usuario de integración",
    //        Email = "Usuario de ejemplo"
    //    };

    //    // Act
    //    var result = await useCase.ExecuteAsync(request);

    //    // Assert
    //    Assert.Equal("Usuario registrado.", result);

    //    var userInDb = context.Users.FirstOrDefault(u => u.Email == "integ@example.com");
    //    Assert.NotNull(userInDb);
    //    Assert.Equal("Usuario de integración", userInDb!.Name);
    //}
}
