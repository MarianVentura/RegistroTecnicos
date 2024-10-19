using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class TrabajosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public int TrabajoId { get; set; }

    [ForeignKey("TrabajoId")]
    public Trabajos? Trabajo { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public int ArticuloId { get; set; }

    [ForeignKey("ArticuloId")]
    public Articulos? Articulos { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public int Cantidad {  get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio.")]
    public decimal Costo { get; set; }
}
