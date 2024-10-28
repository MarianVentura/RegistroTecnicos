using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Cotizaciones
{
    [Key]
    public int CotizacionId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set;}

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Observacion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public decimal Monto { get; set; }

    public ICollection<CotizacionesDetalle>? CotizacionesDetalles { get; set; } = new List<CotizacionesDetalle>();
}
