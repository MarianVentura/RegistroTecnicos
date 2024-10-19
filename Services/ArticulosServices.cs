using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;


namespace RegistroTecnicos.Services
{
    public class ArticulosServices
    {
        private readonly Contexto _contexto;

        public ArticulosServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int ArticuloId)
        {
            return await _contexto.Articulos.AnyAsync(a => a.ArticuloId == ArticuloId);
        }

        private async Task<bool> Insertar(Articulos articulo)
        {
            _contexto.Articulos.Add(articulo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Articulos articulo)
        {
            _contexto.Articulos.Update(articulo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Articulos articulo)
        {
            if (!await Existe(articulo.ArticuloId))
                return await Insertar(articulo);
            else
                return await Modificar(articulo);
        }

        public async Task<bool> Eliminar(int ArticuloId)
        {
            var articuloEliminado = await _contexto.Articulos
                .Where(a => a.ArticuloId == ArticuloId)
                .ExecuteDeleteAsync();
            return articuloEliminado > 0;
        }

        public async Task<Articulos?> Buscar(int ArticuloId)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ArticuloId == ArticuloId);
        }

        public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> ActualizarExistencia(int ArticuloId, int cantidad)
        {
            var articulo = await _contexto.Articulos.FindAsync(ArticuloId);
            if (articulo == null) return false;

            articulo.Existencia += cantidad;
            return await Modificar(articulo);
        }
    }
}
