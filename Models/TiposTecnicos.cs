using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]

        public int TipoTecnicoId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Descripcion { get; set; }
       

    }
}