using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El Campo Descripción es obligatorio")]
        public string? Descripcion { get; set; }
        public decimal SueldoHora { get; set; }
    }
}
