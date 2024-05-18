using System.ComponentModel.DataAnnotations;

namespace RegistrodeTecnicos.Models
{
    public class TipoTecnicos
    {
        [Key]

        public int TipoId { get; set; }
        [Required(ErrorMessage = "El campo no esta lleno")]
        public string Descripcion { get; set; }


    }
}
