using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public decimal Costo { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int Existencia { get; set; }

    
}
