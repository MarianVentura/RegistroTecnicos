using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TiposTecnicos
    {
        [Key]

        public int TiposTecnicosId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"[a-zA-Z\s]+$", ErrorMessage = "No se permiten caracteres ni números, solo letras.")]
        public string? Descripcion { get; set; }


    }
}