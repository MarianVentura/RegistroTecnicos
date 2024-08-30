using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using System.Linq;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.Services
{
    public class TecnicoServices
    {
        private readonly Contexto Contexto;

        public TecnicoServices(Contexto contexto)
        {
            Contexto = contexto;
        }

        //Método Existe
        public async Task<bool> Existe(int TecnicoId)
        {
            return await Contexto.Tecnicos.AnyAsync(t => t.TecnicoId == TecnicoId);

        }

        //Método Insertar
        private async Task<bool> Insertar(Tecnicos tecnico)
        {
            Contexto.Tecnicos.Add(tecnico);
            return await Contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar

        private async Task<bool> Modificar(Tecnicos tecnico)
        {
            Contexto.Tecnicos.Update(tecnico);
            var modificado = await Contexto.SaveChangesAsync() > 0;
            Contexto.Entry(tecnico).State = EntityState.Detached;
            return modificado;
        }

        // Método Guardar
        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            else
            {
                return await Modificar(tecnico);
            }
        }

        // Método Eliminar

        public async Task<bool> Eliminar(int id)
        {
            var Tecnicos = await Contexto.Tecnicos.Where(t => t.TecnicoId == id).ExecuteDeleteAsync();
            return Tecnicos > 0;
        }

        //Método Buscar

        public async Task<Tecnicos?> Buscar(int id)
        {
            return await Contexto.Tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TecnicoId == id);
        }

        //Método Listar

        public async Task <List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
        {
            return await Contexto.Tecnicos
                .Where(criterio)
                .ToListAsync();
        }
    }
}