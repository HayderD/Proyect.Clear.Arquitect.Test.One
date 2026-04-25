using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Clase para modelar transaciones
    /// </summary>
    public class Transaccion
    {
        /// <summary>
        /// Campo unico de tabla
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Id del cliente
        /// </summary>
        [Required]
        public int ClienteId { get; set; }
        /// <summary>
        /// Monto de transacion
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        /// <summary>
        /// Tipo de transacion
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Tipo { get; set; } = string.Empty;
        /// <summary>
        /// Fecha de registro de movimiento transacional
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Estado de trnsacion
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } = string.Empty;
    }
}
