using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class PrioridadesServices
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public PrioridadesServices(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Existe(int PrioridadId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Prioridades.AnyAsync(p => p.PrioridadId == PrioridadId);
    }

    private async Task<bool> Insertar(Prioridades prioridad)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Prioridades.Add(prioridad);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prioridades prioridad)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Prioridades.Update(prioridad);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prioridades prioridad)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        if (prioridad.PrioridadId == 0 || !await Existe(prioridad.PrioridadId))
        {
            contexto.Prioridades.Add(prioridad);
            return await contexto.SaveChangesAsync() > 0;
        }
        else
        {
            contexto.Prioridades.Update(prioridad);
            return await contexto.SaveChangesAsync() > 0;
        }
    }



    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        var prioridadesEliminadas = await contexto.Prioridades
            .Where(p => p.PrioridadId == id)
            .ExecuteDeleteAsync();
        return prioridadesEliminadas > 0;
    }

    public async Task<Prioridades?> Buscar(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PrioridadId == id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExistePrioridad(int prioridadId, string descripcion)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Prioridades
            .AnyAsync(p => p.PrioridadId != prioridadId && p.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}
