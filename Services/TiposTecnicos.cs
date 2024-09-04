using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using System.Linq;
using RegistroTecnicos.Models;
using System.Data.Entity;

namespace RegistroTecnicos.Services;

public class TiposTecnicosServices
{
    private readonly Contexto _contexto;
}

public TiposTecnicosServices(Contexto contexto)
{
    _contexto = contexto;
}

public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
{
    return await _contexto.TiposTecnicos
        .Where(testc => testc.Activo)
        .ToListAsync();
}

public async Task<List<TiposTecnicos>> ObtenetTiposActivos()
{
    return await _contexto.TiposTecnicos
        .Where(t => t.Activo)
        .ToListAsync();
}

public async Task<TiposTecnicos> ObtenerPorId(int id)
{
    return await _contexto.TiposTecnicos
        .AsNoTracking()
        .FirstOrDefaultAsync(t => t.Id == id);
}

