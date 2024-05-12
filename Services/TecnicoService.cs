using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroTecnicos.Services
{
    public class TecnicoService : ITecnicoService
    {
        private readonly ApplicationDbContext _context;

        public TecnicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteTecnico(string nombre)
        {
            return await _context.Tecnicos.AnyAsync(t => t.Nombres == nombre);
        }

        public async Task InsertarTecnico(Tecnico tecnico)
        {
            _context.Add(tecnico);
            await GuardarCambios();
        }

        public async Task ModificarTecnico(Tecnico tecnico)
        {
            _context.Update(tecnico);
            await GuardarCambios();
        }

        public async Task<bool> GuardarTecnico(Tecnico tecnico)
        {
            if (tecnico.TecnicoId == 0)
            {
                await InsertarTecnico(tecnico);
            }
            else
            {
                await ModificarTecnico(tecnico);
            }
            return true; 
        }


        public async Task GuardarCambios()
        {
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTecnico(int tecnicoId)
        {
            var tecnico = await BuscarTecnico(tecnicoId);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                await GuardarCambios();
            }
        }

        public async Task<Tecnico> BuscarTecnico(int tecnicoId)
        {
            return await _context.Tecnicos.FindAsync(tecnicoId);
        }

        public async Task<List<Tecnico>> ListarTecnicos()
        {
            return await _context.Tecnicos.ToListAsync();
        }

        Task ITecnicoService.GuardarTecnico(Tecnico tecnico)
        {
            throw new NotImplementedException();
        }
    }
}
