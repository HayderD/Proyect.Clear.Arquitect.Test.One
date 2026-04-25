using Microsoft.EntityFrameworkCore;
using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Domain.Interfaces;
using Proyect.Clear.Arquitect.Infrastructure;

public class EfTransaccionRepository : ITransaccionesRepository
{
    private readonly AppDbContext _context;

    public EfTransaccionRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Crea objeto en BD
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Transaccion> CrearTransaccionAsync(Transaccion dto)
    {
        await _context.AddAsync(dto);
        await _context.SaveChangesAsync();
        return dto;
    }
/// <summary>
/// Busca objeto por id en BD
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
    public async Task<Transaccion?> GetByIdAsync(int id)
    {
        return await _context.Transacciones
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    /// <summary>
    /// Actaliza ojeto en base de datos
    /// </summary>
    /// <param name="transaccionId"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<bool> ActualizarEstadoAsync(int transaccionId, Transaccion dto)
    {
        var existing = await _context.Transacciones
            .FirstOrDefaultAsync(t => t.Id == transaccionId);

        if (existing == null)
            return false;

        existing.Estado = dto.Estado;

        _context.Transacciones.Update(existing);
        await _context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Consulta por Id objeto en base de datos
    /// </summary>
    /// <param name="clienteId"></param>
    /// <returns></returns>
    public async Task<List<Transaccion>> ObtenerPorClienteIdAsync(int clienteId)
    {
        return await _context.Transacciones
            .Where(t => t.ClienteId == clienteId)
            .ToListAsync();
    }
}