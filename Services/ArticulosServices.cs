using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegistroTecnicos.Services
{
    public class ArticulosServices
    {
        private readonly Contexto _contexto;

        public ArticulosServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Articulos>> ListaArticulos()
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Articulos?> ObtenerArticuloPorId(int id)
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ArticuloId == id);
        }

        public async Task<bool> ActualizarExistencia(int articuloId, decimal cantidad)
        {
            var articulo = await _contexto.Articulos.FindAsync(articuloId);
            if (articulo != null)
            {
                // Asegúrate de que Existencia no se vuelva negativa
                if (articulo.Existencia + cantidad < 0) return false;

                articulo.Existencia += (int)cantidad; // Suponiendo que cantidad es un decimal
                _contexto.Articulos.Update(articulo);
                await _contexto.SaveChangesAsync();
                return true;
            }
            return false; // El artículo no fue encontrado
        }

        public async Task<bool> AgregarCantidad(int articuloId, int cantidad)
        {
            var articulo = await _contexto.Articulos.FindAsync(articuloId);
            if (articulo != null)
            {
                articulo.Existencia += cantidad; // Agregar la cantidad
                _contexto.Articulos.Update(articulo);
                await _contexto.SaveChangesAsync();
                return true;
            }
            return false; // El artículo no fue encontrado
        }
    }
}
