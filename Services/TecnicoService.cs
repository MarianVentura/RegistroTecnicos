using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroTecnicos.Services
{
    public class TecnicoService
    {
        private readonly Contexto _context;
        public TecnicoService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if(!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            else
                return await Modificar(tecnico);
        }

        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            return await _context.SaveChangesAsync() >0;
        }

        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            _context.Update(tecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(int tecnicoId)
        {
            return await _context.Tecnicos.AnyAsync(t => t.TecnicoId == tecnicoId);
        }

        public async Task<bool> Existe(string? nombre)
        {
            return await _context.Tecnicos.AnyAsync(t => t.Nombres.Equals(nombre));
        }

        public async Task<bool> Existe(int tecnicoId, string? nombre)
        {
            return await _context.Tecnicos.AnyAsync(t => t.TecnicoId != tecnicoId && t.Nombres.Equals(nombre));
        }

        public async Task<bool> Eliminar(int id)
        {
            var tecnico = await _context.Tecnicos
                .Where(t => t.TecnicoId == id)
                .ExecuteDeleteAsync();
            return tecnico > 0;
        }

        public async Task<Tecnicos?> Buscar(int id)
        {
            return await _context.Tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TecnicoId == id);
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await _context.Tecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}

