using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        public string Nombres { get; set; }

        public decimal SueldoHora { get; set; }
    }
}
