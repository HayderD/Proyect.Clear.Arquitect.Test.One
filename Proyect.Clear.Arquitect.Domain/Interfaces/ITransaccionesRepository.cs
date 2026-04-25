using Proyect.Clear.Arquitect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Domain.Interfaces
{
    public interface ITransaccionesRepository
    {
        /// <summary>
        /// Consulta la transaccion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Transaccion?> GetByIdAsync(int id);
        /// <summary>
        /// Crear una transaccion en BD
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Transaccion> CrearTransaccionAsync(Transaccion dto);
        /// <summary>
        /// Cambiar el estado de una transaccion en BD
        /// </summary>
        /// <param name="transaccionId"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<bool> ActualizarEstadoAsync(int transaccionId, Transaccion dto);
        /// <summary>
        /// Consulta por Id objeto en base de datos
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        Task<List<Transaccion>> ObtenerPorClienteIdAsync(int clienteId);
    }
}
