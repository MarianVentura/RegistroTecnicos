using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using System.Linq;
using RegistrodeTecnicos.Models;

namespace RegistroTecnicos.Service
{
    public class TecnicoService
    {
        private readonly Contexto Contexto;

        public TecnicoService(Contexto contexto)
        {
            Contexto = contexto;
        }

        //Metodo Existente
        public async Task<bool> Existe(int TecnicoId)
        {
            return await Contexto.Tecnicos.AnyAsync(t => t.TecnicoId == TecnicoId);

        }

        //Metodo Insertar
        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            Contexto.Tecnicos.Add(tecnico);
            return await Contexto.SaveChangesAsync() > 0;
        }

        // Metodo Modificar

        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            Contexto.Tecnicos.Update(tecnico);
            var modificado = await Contexto.SaveChangesAsync() > 0;
            Contexto.Entry(tecnico).State = EntityState.Detached;
            return modificado;
        }

        // Metodo guardar
        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            else
            {
                return await Modificar(tecnico);
            }
        }

        // Metodo eliminar

        public async Task<bool> Eliminar(int id)
        {
            var Tecnicos = await Contexto.Tecnicos.Where(t => t.TecnicoId == id).ExecuteDeleteAsync();
            return Tecnicos > 0;
        }

        //Metodo Buscar

        public async Task<Tecnicos?> Buscar(int id)
        {
            return await Contexto.Tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TecnicoId == id);
        }

        //Metodo listar

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return Contexto.Tecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
