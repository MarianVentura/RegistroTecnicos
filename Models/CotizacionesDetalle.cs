using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class CotizacionesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int CotizacionId { get; set; }

        [ForeignKey("CotizacionId")]
        public Cotizaciones? Cotizacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int ArticuloId { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulos? Articulo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public decimal Precio { get; set; }
    }
}
