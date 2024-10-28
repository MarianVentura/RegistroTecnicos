using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class CotizacionesDetalleServices
    {
        private readonly IDbContextFactory<Contexto> _dbFactory;

        public CotizacionesDetalleServices(IDbContextFactory<Contexto> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Guardar(CotizacionesDetalle cotizacionDetalle)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();

            if (!await Existe(cotizacionDetalle.DetalleId))
            {
                return await Insertar(cotizacionDetalle, contexto);
            }
            else
            {
                return await Modificar(cotizacionDetalle, contexto);
            }
        }

        private async Task<bool> Modificar(CotizacionesDetalle cotizacionDetalle, Contexto contexto)
        {
            contexto.CotizacionesDetalle.Update(cotizacionDetalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Insertar(CotizacionesDetalle cotizacionDetalle, Contexto contexto)
        {
            await contexto.CotizacionesDetalle.AddAsync(cotizacionDetalle);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Existe(int detalleId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.CotizacionesDetalle.AnyAsync(cd => cd.DetalleId == detalleId);
        }

        public async Task<CotizacionesDetalle?> Buscar(int detalleId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.CotizacionesDetalle
                .Include(cd => cd.Articulo)
                .AsNoTracking()
                .FirstOrDefaultAsync(cd => cd.DetalleId == detalleId);
        }

        public async Task<bool> Eliminar(CotizacionesDetalle cotizacionDetalle)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.CotizacionesDetalle
                .AsNoTracking()
                .Where(cd => cd.DetalleId == cotizacionDetalle.DetalleId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<CotizacionesDetalle>> Listar(Expression<Func<CotizacionesDetalle, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.CotizacionesDetalle
                .Include(cd => cd.Articulo)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
