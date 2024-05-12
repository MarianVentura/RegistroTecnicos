using RegistroTecnicos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroTecnicos.Services
{
    public interface ITecnicoService
    {
        Task<bool> ExisteTecnico(string nombre);
        Task InsertarTecnico(Tecnico tecnico);
        Task ModificarTecnico(Tecnico tecnico);
        Task GuardarTecnico(Tecnico tecnico);
        Task GuardarCambios();
        Task EliminarTecnico(int tecnicoId);

        Task<Tecnico> BuscarTecnico(int tecnicoId);
        Task<List<Tecnico>> ListarTecnicos();

    }
}
