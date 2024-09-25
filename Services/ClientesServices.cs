using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using System.Linq;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class ClientesServices
{
    private readonly Contexto _contexto;

    public ClientesServices(Contexto contexto)
    {
        _contexto = contexto;
    }

   
    public async Task<bool> Existe(int ClienteId)
    {
        return await _contexto.Clientes.AnyAsync(c => c.ClienteId == ClienteId);
    }

    
    private async Task<bool> Insertar(Clientes cliente)
    {
        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        _contexto.Update(cliente);
        return await _contexto.SaveChangesAsync() > 0;
        
    }

    
    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        else
        {
            return await Modificar(cliente);
        }
    }

    
    public async Task<bool> Eliminar(int id)
    {
        var clientesEliminados = await _contexto.Clientes
            .Where(c => c.ClienteId == id)
            .ExecuteDeleteAsync();
        return clientesEliminados > 0;
    }

   
    public async Task<Clientes?> Buscar(int clienteId)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    
    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return await _contexto.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }


    public async Task<bool> ExisteCliente(int clienteId, string nombres, string whatsApp)
    {
        return await _contexto.Clientes
            .AnyAsync(e => e.ClienteId != clienteId && e.Nombres.ToLower().Equals(nombres.ToLower()));

    }

}
