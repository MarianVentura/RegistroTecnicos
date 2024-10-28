using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services;

public class ClientesServices
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ClientesServices(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Existe(int ClienteId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Clientes.AnyAsync(c => c.ClienteId == ClienteId);
    }

    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Update(cliente);
        return await contexto.SaveChangesAsync() > 0;
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
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        var clientesEliminados = await contexto.Clientes
            .Where(c => c.ClienteId == id)
            .ExecuteDeleteAsync();
        return clientesEliminados > 0;
    }

    public async Task<Clientes?> Buscar(int clienteId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ExisteCliente(int clienteId, string nombres, string whatsApp)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Clientes
            .AnyAsync(e => e.ClienteId != clienteId && e.Nombres.ToLower().Equals(nombres.ToLower()));
    }
}
