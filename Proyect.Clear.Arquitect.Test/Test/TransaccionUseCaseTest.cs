using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Proyect.Clear.Arquitect.Application.Requests.EnumTransaccion;

namespace Proyect.Clear.Arquitect.Test.Test
{
    public class TransaccionUseCaseTest
    {
        [Fact]
        public async Task ObtenerTransaccionesPorCliente_Test()
        {
            // Arrange
            var repo = new FakeTransaccionRepository();

            var field = typeof(FakeTransaccionRepository)
                .GetField("_transacciones", BindingFlags.NonPublic | BindingFlags.Instance);

            var data = new List<Transaccion>
    {
        new Transaccion
        {
            Id = 1,
            ClienteId = 10,
            Monto = 100,
            Tipo = TipoTransaccion.Credito.ToString(),
            Estado = EstadoTransaccion.Procesada.ToString(),
            Fecha = DateTime.Now
        },
        new Transaccion
        {
            Id = 2,
            ClienteId = 10,
            Monto = 200,
            Tipo = TipoTransaccion.Debito.ToString(),
            Estado = EstadoTransaccion.Pendiente.ToString(),
            Fecha = DateTime.Now
        },
        new Transaccion
        {
            Id = 3,
            ClienteId = 99,
            Monto = 300,
            Tipo = TipoTransaccion.Credito.ToString(),
            Estado = EstadoTransaccion.Procesada.ToString(),
            Fecha = DateTime.Now
        }
    };

            field?.SetValue(repo, data);

            // Act
            var result = await repo.ObtenerPorClienteIdAsync(10);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, x => Assert.Equal(10, x.ClienteId));
        }
    }

       


    /// <summary>
    /// Tipos de transacciones
    /// </summary>
    public enum TipoTransaccion
    {
        Credito,
        Debito
    }

    /// <summary>
    /// Estado de transaccion
    /// </summary>
    public enum EstadoTransaccion
    {
        Pendiente,
        Procesada,
        Rechazada
    }
}
