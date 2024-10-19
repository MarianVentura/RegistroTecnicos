using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegistroTecnicos.Services
{
    public class TrabajosDetalleServices
    {
        private readonly Contexto _contexto;
        private readonly ArticulosServices _articulosServices;

        public TrabajosDetalleServices(Contexto contexto, ArticulosServices articulosServices)
        {
            _contexto = contexto;
            _articulosServices = articulosServices;
        }

        public async Task<bool> Existe(int detalleId)
        {
            return await _contexto.TrabajosDetalles.AnyAsync(td => td.DetalleId == detalleId);
        }

        private async Task<bool> Insertar(TrabajosDetalle trabajosDetalle)
        {
            // Actualizar la existencia del artículo al agregar el detalle
            var exito = await _articulosServices.ActualizarExistencia(trabajosDetalle.ArticuloId, -trabajosDetalle.Cantidad);
            if (!exito) return false;

            _contexto.TrabajosDetalles.Add(trabajosDetalle);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(TrabajosDetalle trabajosDetalle)
        {
            var detalleExistente = await _contexto.TrabajosDetalles.AsNoTracking().FirstOrDefaultAsync(td => td.DetalleId == trabajosDetalle.DetalleId);
            if (detalleExistente == null) return false;

            // Calcular la diferencia en cantidad y actualizar la existencia
            int diferenciaCantidad = trabajosDetalle.Cantidad - detalleExistente.Cantidad;
            var exito = await _articulosServices.ActualizarExistencia(trabajosDetalle.ArticuloId, -diferenciaCantidad);
            if (!exito) return false;

            _contexto.TrabajosDetalles.Update(trabajosDetalle);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TrabajosDetalle trabajosDetalle)
        {
            if (!await Existe(trabajosDetalle.DetalleId))
                return await Insertar(trabajosDetalle);
            else
                return await Modificar(trabajosDetalle);
        }

        public async Task<bool> Eliminar(int detalleId)
        {
            var detalle = await Buscar(detalleId);
            if (detalle == null) return false;

            // Revertir la existencia del artículo al eliminar el detalle
            var exito = await _articulosServices.ActualizarExistencia(detalle.ArticuloId, detalle.Cantidad);
            if (!exito) return false;

            var detalleEliminado = await _contexto.TrabajosDetalles
                .Where(td => td.DetalleId == detalleId)
                .ExecuteDeleteAsync();
            return detalleEliminado > 0;
        }

        public async Task<TrabajosDetalle?> Buscar(int detalleId)
        {
            return await _contexto.TrabajosDetalles
                .AsNoTracking()
                .Include(td => td.Articulos)
                .FirstOrDefaultAsync(td => td.DetalleId == detalleId);
        }

        public async Task<List<TrabajosDetalle>> Listar(Expression<Func<TrabajosDetalle, bool>> criterio)
        {
            return await _contexto.TrabajosDetalles
                .AsNoTracking()
                .Include(td => td.Articulos)
                .Where(criterio)
                .ToListAsync();
        }
    }
}
