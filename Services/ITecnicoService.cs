using RegistroTecnicos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistroTecnicos.Services
{
    public interface ITecnicoService
    {
        Task<bool> ExisteTecnico(string nombre);
        Task InsertarTecnico(Tecnicos tecnico);
        Task ModificarTecnico(Tecnicos tecnico);
        Task GuardarTecnico(Tecnicos tecnico);
        Task GuardarCambios();
        Task EliminarTecnico(int tecnicoId);

        Task<Tecnicos> BuscarTecnico(int tecnicoId);
        Task<List<Tecnicos>> ListarTecnicos();

    }
}
