using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

public class ArticuloServices
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ArticuloServices(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Articulos>> ListaArticulos()
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Articulos
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Articulos?> ObtenerArticuloPorId(int id)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Articulos
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.ArticuloId == id);
    }

    public async Task<bool> ActualizarExistencia(int articuloId, int cantidad)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        var articulo = await contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            int nuevaExistencia = articulo.Existencia - cantidad;

            if (nuevaExistencia < 0)
            {
                throw new InvalidOperationException("No hay suficiente existencia para reducir.");
            }

            articulo.Existencia = nuevaExistencia;
            contexto.Articulos.Update(articulo);
            await contexto.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> AgregarCantidad(int articuloId, int cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad a agregar debe ser mayor que cero.");
        }

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        var articulo = await contexto.Articulos.FindAsync(articuloId);

        if (articulo != null)
        {
            articulo.Existencia += cantidad;
            contexto.Articulos.Update(articulo);
            await contexto.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
