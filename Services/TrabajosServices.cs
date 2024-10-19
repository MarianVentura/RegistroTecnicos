using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegistroTecnicos.Services
{
    public class TrabajosServices
    {
        private readonly Contexto _contexto;
        private readonly ArticulosServices _articulosServices;

        public TrabajosServices(Contexto contexto, ArticulosServices articulosServices)
        {
            _contexto = contexto;
            _articulosServices = articulosServices;
        }

        public async Task<bool> Existe(int trabajoId)
        {
            return await _contexto.Trabajos.AnyAsync(t => t.TrabajoId == trabajoId);
        }

        public async Task<bool> Insertar(Trabajos trabajo)
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
                return await Modificar(trabajo);
        }

        public async Task<bool> Eliminar(int id)
        {
            // Obtener los detalles antes de eliminar
            var detalles = await ListarDetalles(id);

            // Revertir la existencia de los artículos en los detalles
            foreach (var detalle in detalles)
            {
                await _articulosServices.ActualizarExistencia(detalle.ArticuloId, detalle.Cantidad);
            }

            var trabajosEliminados = await _contexto.Trabajos
                .Where(t => t.TrabajoId == id)
                .ExecuteDeleteAsync();

            return trabajosEliminados > 0;
        }

        public async Task<List<TrabajosDetalle>> ListarDetalles(int trabajoId)
        {
            // Busca los detalles del trabajo específico
            var detalles = await _contexto.TrabajosDetalles
                .Where(td => td.TrabajoId == trabajoId)
                .ToListAsync();

            return detalles;
        }

        public async Task<List<TrabajosDetalle>> ObtenerDetalles(int trabajoId)
        {
            return await _contexto.TrabajosDetalles
                .AsNoTracking()
                .Where(t => t.TrabajoId == trabajoId)
                .ToListAsync();
        }

        public async Task<bool> EliminarDetalle(int detalleId)
        {
            var trabajoDetalleDb = await _contexto.TrabajosDetalles.FindAsync(detalleId);
            if (trabajoDetalleDb != null)
            {
                // Revertir la existencia del artículo antes de eliminar el detalle
                await _articulosServices.ActualizarExistencia(trabajoDetalleDb.ArticuloId, trabajoDetalleDb.Cantidad);

                _contexto.TrabajosDetalles.Remove(trabajoDetalleDb);
                await _contexto.SaveChangesAsync();
                return true;
            }
            return false;
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

        public async Task<List<Clientes>> ObtenerClientes()
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

        public async Task<List<Articulos>> ListarArticulos()
        {
            return await _contexto.Articulos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
