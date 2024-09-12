﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using RegistroTecnicos.DAL;
using System.Linq.Expressions;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class TrabajosServices
{
    private readonly Contexto Contexto;

    public TrabajosServices(Contexto contexto)
    {
        Contexto = contexto;
    }

    //Método Existe
    public async Task<bool> Existe(int TrabajoId)
    {
        return await Contexto.Trabajos.AnyAsync(t => t.TrabajoId == TrabajoId);
    }

    //Método Insertar
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        Contexto.Trabajos.Add(trabajo);
        return await Contexto.SaveChangesAsync() > 0;
    }

    //Método Modificar
    private async Task<bool> Modificar(Trabajos trabajo)
    {
        Contexto.Trabajos.Update(trabajo);
        var modificado = await Contexto.SaveChangesAsync() > 0;
        Contexto.Entry(trabajo).State = EntityState.Detached;
        return modificado;
    }

    //Método Guardar
    public async Task<bool> Guardar(Trabajos trabajo)
    {
        if (!await Existe(trabajo.TrabajoId))
            return await Insertar(trabajo);
        else
        {
            return await Modificar(trabajo);
        }
    }

    //Método Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var trabajosEliminados = await Contexto.Trabajos
            .Where(t => t.TrabajoId == id)
            .ExecuteDeleteAsync();
        return trabajosEliminados > 0;
    }

    //Método Buscar
    public async Task<Trabajos?> Buscar(int id)
    {
        return await Contexto.Trabajos
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }

    //Método Listar
    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await Contexto.Trabajos
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .Where(criterio)
            .ToListAsync();
    }
}