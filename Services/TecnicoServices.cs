using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TecnicoServices
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public TecnicoServices(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Existe(int tecnicoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos.AnyAsync(t => t.TecnicoId == tecnicoId);
    }


    private async Task<bool> Insertar(Tecnicos tecnico)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Tecnicos.Add(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Tecnicos tecnico)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Update(tecnico);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (!await Existe(tecnico.TecnicoId))
        {
            return await Insertar(tecnico);
        }
        else
        {
            return await Modificar(tecnico);
        }
    }

    public async Task<bool> Eliminar(Tecnicos tecnico)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .Where(t => t.TecnicoId == tecnico.TecnicoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Tecnicos?> Buscar(int TecnicoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == TecnicoId);
    }

    public async Task<bool> ExisteTecnico(int TecnicoId, string nombre)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .AnyAsync(t => t.TecnicoId != TecnicoId && t.Nombres.ToLower() == nombre.ToLower());
    }


    public async Task<Tecnicos?> BuscarTipo(int tecnicoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .Include(t => t.TipoTecnico)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TecnicoId == tecnicoId);
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Tecnicos
            .Include(t => t.TipoTecnico)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
