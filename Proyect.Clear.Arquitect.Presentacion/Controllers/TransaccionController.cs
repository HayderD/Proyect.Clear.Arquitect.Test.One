using Microsoft.AspNetCore.Mvc;
using Proyect.Clear.Arquitect.Application.UseCases;

namespace Proyect.Clear.Arquitect.Presentacion.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proyect.Clear.Arquitect.Application.Requests;

    [ApiController]
    [Route("api")]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionUseCase _useCase;

        public TransaccionController(TransaccionUseCase useCase)
        {
            _useCase = useCase;
        }

        /// <summary>
        /// Obtener resumen
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        [HttpGet("clientes/{clienteId}/resumen")]
        public async Task<IActionResult> ObtenerResumen(int clienteId)
        {
            try
            {
                var resultado = await _useCase.ObtenerResumenClienteAsync(clienteId);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno", detalle = ex.Message });
            }
        }

       /// <summary>
       /// Crear transaccion
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>
        [HttpPost("transacciones")]
        public async Task<IActionResult> Crear([FromBody] TransaccionRequest request)
        {
            try
            {
                var resultado = await _useCase.CrearTransaccionAsync(request);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno", detalle = ex.Message });
            }
        }

     /// <summary>
     /// Actualizar estado
     /// </summary>
     /// <param name="id"></param>
     /// <param name="request"></param>
     /// <returns></returns>
        [HttpPost("transacciones/{id}/estado")]
        public async Task<IActionResult> ActualizarEstado(int id, [FromBody] TransaccionRequestUpdate request)
        {
            try
            {
                var resultado = await _useCase.ActualizarEstadoAsync(id, request);

                if (!resultado)
                    return NotFound(new { mensaje = "Transacción no encontrada" });

                return Ok(new { mensaje = "Estado actualizado correctamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno", detalle = ex.Message });
            }
        }
    }
}
