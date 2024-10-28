using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class CotizacionesServices
    {
        private readonly IDbContextFactory<Contexto> _dbFactory;

        public CotizacionesServices(IDbContextFactory<Contexto> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Cotizaciones cotizaciones)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();

            if (!await Existe(cotizaciones.CotizacionId))
            {
                return await Insertar(cotizaciones, contexto);
            }
            else
            {
                return await Modificar(cotizaciones, contexto);
            }
        }

        private async Task<bool> Modificar(Cotizaciones cotizaciones, Contexto contexto)
        {
            contexto.Cotizaciones.Update(cotizaciones);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Insertar(Cotizaciones cotizaciones, Contexto contexto)
        {
            await contexto.Cotizaciones.AddAsync(cotizaciones);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Existe(int cotizacionId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones.AnyAsync(c => c.CotizacionId == cotizacionId);
        }

        public async Task<Cotizaciones?> Buscar(int cotizacionId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .Include(c => c.Cliente)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CotizacionId == cotizacionId);
        }

        public async Task<bool> Eliminar(Cotizaciones cotizaciones)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .AsNoTracking()
                .Where(c => c.CotizacionId == cotizaciones.CotizacionId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Cotizaciones>> Listar(Expression<Func<Cotizaciones, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Cotizaciones
                .Include(c => c.Cliente)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
