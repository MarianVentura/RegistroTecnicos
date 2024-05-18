using Microsoft.EntityFrameworkCore;
using RegistrodeTecnicos.Models;
using RegistroTecnicos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistrodeTecnicos.Service
{
    public class TipoTecnicoService
    {
        private readonly Contexto _contexto;

        public TipoTecnicoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Método Existente
        public async Task<bool> Existe(int TipoTecnicoId)
        {
            return await _contexto.TipoTecnicos.AnyAsync(t => t.TipoId == TipoTecnicoId);
        }

        // Método Insertar
        private async Task<bool> Insertar(TipoTecnicos tipoTecnicos)
        {
            _contexto.TipoTecnicos.Add(tipoTecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(TipoTecnicos tipoTecnicos)
        {
            _contexto.TipoTecnicos.Update(tipoTecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método guardar
        public async Task<bool> Guardar(TipoTecnicos tipoTecnicos)
        {
            if (!await Existe(tipoTecnicos.TipoId))
                return await Insertar(tipoTecnicos);
            else
                return await Modificar(tipoTecnicos);
        }

        // Método eliminar
        public async Task<bool> Eliminar(int id)
        {
            var tipoTecnico = await _contexto.TipoTecnicos.FindAsync(id);
            if (tipoTecnico == null)
                return false;

            _contexto.TipoTecnicos.Remove(tipoTecnico);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método buscar
        public async Task<TipoTecnicos?> Buscar(int id)
        {
            return await _contexto.TipoTecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        // Método listar
        public async Task<List<TipoTecnicos>> Listar(Expression<Func<TipoTecnicos, bool>> criterio)
        {
            return await _contexto.TipoTecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}