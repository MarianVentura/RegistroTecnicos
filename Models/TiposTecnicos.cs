using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TipoTecnico
    {
        public int TipoId { get; set; }
        public string? Descripcion { get; set; }
    }

}
