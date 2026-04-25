using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Application.Requests
{
    public class EnumTransaccion
    {
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
}
