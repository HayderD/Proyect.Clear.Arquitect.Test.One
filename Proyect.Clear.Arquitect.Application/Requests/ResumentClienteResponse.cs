using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Application.Requests
{
    using System;

    public class ResumentClienteResponse
    {
        /// <summary>
        /// Saldo actual (créditos - débitos procesados)
        /// </summary>
        public decimal SaldoActual { get; set; }

        /// <summary>
        /// Cantidad de transacciones pendientes
        /// </summary>
        public int CantidadPendientes { get; set; }

        /// <summary>
        /// Cantidad de transacciones procesadas
        /// </summary>
        public int CantidadProcesadas { get; set; }

        /// <summary>
        /// Cantidad de transacciones rechazadas
        /// </summary>
        public int CantidadRechazadas { get; set; }

        /// <summary>
        /// Fecha de la última transacción procesada
        /// </summary>
        public DateTime? UltimaTransaccionProcesada { get; set; }
    }
}
