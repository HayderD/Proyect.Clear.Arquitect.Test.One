using static Proyect.Clear.Arquitect.Application.Requests.EnumTransaccion;

namespace Proyect.Clear.Arquitect.Application.Requests
{
    /// <summary>
    /// Dto de Transacciones
    /// </summary>
    public class TransaccionResponse
    {
     /// <summary>
     /// Id de registro unico en tabla
     /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id del cliente
        /// </summary>
        public int ClienteId { get; set; }
        /// <summary>
        /// Monto de transaccion
        /// </summary>
        public decimal Monto { get; set; }
        /// <summary>
        /// Tipo de transacion
        /// </summary>
        public TipoTransaccion  Tipo { get; set; } = TipoTransaccion.Debito;
        /// <summary>
        /// Estado de trnsacion
        /// </summary>
        public EstadoTransaccion Estado { get; set; } = EstadoTransaccion.Pendiente;
        /// <summary>
        /// Fecha de registro de movimiento transacional
        /// </summary>
        public String Fecha { get; set; } = string.Empty;
    }

    
}
