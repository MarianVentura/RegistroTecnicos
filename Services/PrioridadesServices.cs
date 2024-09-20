using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class PrioridadesServices
{
    private readonly Contexto _contexto;

    public PrioridadesServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int PrioridadId)
    {
        return await _contexto.Prioridades.AnyAsync(p => p.PrioridadId == PrioridadId);
    }

    private async Task<bool> Insertar(Prioridades prioridad)
    {
        _contexto.Prioridades.Add(prioridad);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        _contexto.Prioridades.Update(prioridad);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(prioridad).State = EntityState.Detached;
        return modificado;
    }

    public async Task<bool> Guardar(Prioridades prioridad)
    {
        if (!await Existe(prioridad.PrioridadId))
            return await Insertar(prioridad);
        else 
            return await Modificar(prioridad);
    }

    public async Task<bool> Eliminar(int id)
    {
        var prioridadesEliminadas = await _contexto.Prioridades
            .Where(p => p.PrioridadId == id)
            .ExecuteDeleteAsync();
        return prioridadesEliminadas > 0;
    }

    public async Task<Prioridades?> Buscar(int id)
    {
        return await _contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrioridadId == id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        return await _contexto.Prioridades
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExisteDescripcion(int prioridadId, string descripcion)
    {
        return await _contexto.Prioridades
            .AnyAsync(p => p.PrioridadId != prioridadId && p.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
