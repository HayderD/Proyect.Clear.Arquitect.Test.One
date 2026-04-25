using Proyect.Clear.Arquitect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Test.Fakes
{
    public class FakeTransaccionRepository
    {
        private List<Transaccion> _transacciones = new();

        public Task<List<Transaccion>> ObtenerPorClienteIdAsync(int clienteId)
        {
            return Task.FromResult(
                _transacciones.Where(x => x.ClienteId == clienteId).ToList()
            );
        }
    }
}
