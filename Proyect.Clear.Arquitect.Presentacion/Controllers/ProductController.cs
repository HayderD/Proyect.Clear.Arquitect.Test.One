using Microsoft.AspNetCore.Mvc;
using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Application.UseCases;

namespace Proyect.Clear.Arquitect.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductUseCase _useCase;
        public ProductController(ProductUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _useCase.AddAsync(request);

            if (result == null)
                return StatusCode(500, "Error al registrar el producto.");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _useCase.UpdateAsync(id, request);

            if (result == null)
                return NotFound("Producto no encontrado.");

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _useCase.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _useCase.GetByIdAsync(id);

            if (result == null)
                return NotFound("Producto no encontrado.");

            return Ok(result);
        }

        [HttpGet("price/{preci}")]
        public async Task<IActionResult> GetByPrice(double preci)
        {
            var result = await _useCase.ByPrecisAsync(preci);

            if (result == null || !result.Any())
                return NotFound("Producto(s) no encontrado(s).");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var success = await _useCase.DeleteAsync(id);

            if (!string.IsNullOrEmpty(success))
                return NotFound(success);

            return NoContent();
        }

    }
}
