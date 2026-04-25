using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Test.Fakes;
using System.Reflection;

namespace Proyect.Clear.Arquitect.Test.Test
{


    public class RegisterUserUseCaseTests
    {
        [Fact]
        public async Task GetPriceMinAsync_Test()
        {
            // Arrange
            var repo = new FakeProductRepository();

            var field = typeof(FakeProductRepository)
                .GetField("_products", BindingFlags.NonPublic | BindingFlags.Instance);

            var productsList = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Camisa XL", Description = "Marca confortable de algodon", Price = 50000 },
                new Product { Id = Guid.NewGuid(), Name = "Pantalon 32", Description = "Lino con textura agradable", Price = 150000 },
                new Product { Id = Guid.NewGuid(), Name = "Zapatos 42", Description = "De cuerro latino", Price = 200000 }
            };

            // inyecta la lista directamente usando reflexión
            field?.SetValue(repo, productsList);

            // Act
            var result = await repo.GetPriceMinAsync(100);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.DoesNotContain(result, p => p.Price < 100);
        }



    }

}
