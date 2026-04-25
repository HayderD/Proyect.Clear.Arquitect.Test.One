using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Application.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransaccionRequest
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ClienteId debe ser mayor a 0")]
        public int ClienteId { get; set; }
        /// <summary>
        /// Monto de transaccion
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero")]
        public decimal Monto { get; set; }
        /// <summary>
        /// Tipo de transacion
        /// </summary>
        [Required]
        [RegularExpression("^(credito|debito)$", ErrorMessage = "Tipo debe ser 'credito' o 'debito'")]
        public string Tipo { get; set; } = string.Empty;
        /// <summary>
        /// Estado de trnsacion
        /// </summary>
        public string Estado { get; set; } = string.Empty;
    }

    public class TransaccionRequestUpdate
    {      
        /// <summary>
        /// Estado de trnsacion
        /// </summary>
        public string Estado { get; set; } = string.Empty;
    }
}
