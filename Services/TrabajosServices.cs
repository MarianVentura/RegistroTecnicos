using Microsoft.EntityFrameworkCore;
using System.Linq;
using RegistroTecnicos.DAL;
using System.Linq.Expressions;
using RegistroTecnicos.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace RegistroTecnicos.Services;

public class TrabajosServices
{
    private readonly Contexto _contexto;
    

    public TrabajosServices(Contexto contexto)
    {
        _contexto = contexto;
        
    }

    public async Task<bool> Existe(int TrabajoId)
    {
        return await _contexto.Trabajos.AnyAsync(t => t.TrabajoId == TrabajoId);
    }

    
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        _contexto.Trabajos.Add(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Trabajos trabajo)
    {
        _contexto.Trabajos.Update(trabajo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Trabajos trabajo)
    {
        if (!await Existe(trabajo.TrabajoId))
            return await Insertar(trabajo);
        else
        {
            return await Modificar(trabajo);
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        var trabajosEliminados = await _contexto.Trabajos
            .Where(t => t.TrabajoId == id)
            .ExecuteDeleteAsync();
        return trabajosEliminados > 0;
    }

 
    public async Task<Trabajos?> Buscar(int id)
    {
        return await _contexto.Trabajos
            .AsNoTracking()
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .Include(t => t.Prioridades)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }

    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await _contexto.Trabajos
            .AsNoTracking()
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .Include(t => t.Prioridades)
            .Where(criterio)
            .OrderBy(t => t.Prioridades.PrioridadId)
            .ToListAsync();
    }

    public async Task<List<Clientes>> ObtnerClientes()
    {
        return await _contexto.Clientes.ToListAsync();
    }

    public async Task<List<Tecnicos>> ObtenerTecnicos()
    {
        return await _contexto.Tecnicos.ToListAsync();
    }

    public async Task<List<Prioridades>> ObtenerPrioridades()
    {
        return await _contexto.Prioridades.ToListAsync();
    }

    

}