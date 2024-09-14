using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using System.Linq;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class ClientesServices
{
    private readonly Contexto Contexto;

    public ClientesServices(Contexto contexto)
    {
        Contexto = contexto;
    }

    //Método Existe
    public async Task<bool> Existe(int ClienteId)
    {
        return await Contexto.Clientes.AnyAsync(c => c.ClienteId == ClienteId);
    }

    //Método Insertar
    private async Task<bool> Insertar(Clientes cliente)
    {
        Contexto.Clientes.Add(cliente);
        return await Contexto.SaveChangesAsync() > 0;
    }

    //Método Modificar
    private async Task<bool> Modificar(Clientes cliente)
    {
        Contexto.Clientes.Add(cliente);
        var modificado = await Contexto.SaveChangesAsync() > 0;
        Contexto.Entry(cliente).State = EntityState.Detached;
        return modificado;
    }

    //Método Guardar
    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
            return await Insertar(cliente);
        else
        {
            return await Modificar(cliente);
        }
    }

    //Método Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var clientesEliminados = await Contexto.Clientes
            .Where(c => c.ClienteId == id)
            .ExecuteDeleteAsync();
        return clientesEliminados > 0;
    }

    //Método Buscar
    public async Task<Clientes?> Buscar(int id)
    {
        return await Contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    //Método Listar
    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        return await Contexto.Clientes
            .Where(criterio)
            .ToListAsync();
    }

    //Método Existe Cliente
    public async Task<bool> ExisteCliente(int clienteId, string nombres)
    {
        return await Contexto.Clientes
            .AnyAsync(e => e.ClienteId != clienteId && e.Nombres.ToLower().Equals(nombres.ToLower()));

    }

}
