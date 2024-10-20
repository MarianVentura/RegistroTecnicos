using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class TrabajosDetalle
{
    [Key]


    public int? DetalleId { get; set; }

    [ForeignKey("TrabajosId")]
    public Trabajos? Trabajos { get; set; }
    public int? TrabajosId { get; set; }


    [ForeignKey("ArticuloId")]
    public Articulos? Articulos { get; set; }
    public int? ArticuloId { get; set; }


    [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
    public decimal? Precio { get; set; }

    [Required(ErrorMessage = "Este Campo debe de ser obligatorio")]
    public decimal? Costo { get; set; }


}