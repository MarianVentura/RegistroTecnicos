using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]

        public int TipoTecnicoId { get; set; }
        [Required(ErrorMessage = "El campo no esta lleno")]
        public string? Descripcion { get; set; }


    }
}