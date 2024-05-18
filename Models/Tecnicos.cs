using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrodeTecnicos.Models
{
    public class Tecnicos
    {
        [Key]

        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El campo no esta lleno")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo no esta lleno")]
        public float? Sueldohora { get; set; }

        [ForeignKey("TipoTecnico")]
        public int TipoId { get; set; }
    }
}

