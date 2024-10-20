﻿using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class TiposTecnicosServices
{
    private readonly Contexto _contexto;

    public TiposTecnicosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int tiposTecnicosId)
    {
        return await _contexto.TiposTecnicos.AnyAsync(t => t.TipoTecnicoId == tiposTecnicosId);

    }

    public async Task<bool> ExisteDescripcion(string? descripcion)
    {
        return await _contexto.TiposTecnicos.AnyAsync(t => t.Descripcion == descripcion);
    }

    private async Task<bool> Insertar(TiposTecnicos tiposTecnicos)
    {
        await _contexto.TiposTecnicos.AddAsync(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(TiposTecnicos tiposTecnicos)
    {
        _contexto.Update(tiposTecnicos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(TiposTecnicos tiposTecnicos)
    {
        if (!await Existe(tiposTecnicos.TipoTecnicoId))
        {
            return await Insertar(tiposTecnicos);
        }
        else
        {
            return await Modificar(tiposTecnicos);
        }
            
    }

    public async Task<bool> Eliminar(int id)
    {
        return await _contexto.TiposTecnicos
            .Where(tipos => tipos.TipoTecnicoId == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<TiposTecnicos?> Buscar(int id)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TipoTecnicoId == id);
    }

    public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
    {
        return await _contexto.TiposTecnicos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExisteTipoTecnico(int id, string? descripcion)
    {
        return await _contexto.TiposTecnicos.AnyAsync(e => e.TipoTecnicoId != id && e.Descripcion.ToLower().Equals(descripcion.ToLower()));
    }
}