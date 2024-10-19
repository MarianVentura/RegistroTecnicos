using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajoId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public int TecnicoId { get; set; }

    [ForeignKey("TecnicoId")]
    public Tecnicos? Tecnico { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public decimal Monto { get; set; }

    [ForeignKey("Prioridades")]
    public int PrioridadId {  get; set; }
    public Prioridades? Prioridades { get; set; }

    public ICollection<TrabajosDetalle>? TrabajoDetalles { get; set; } = new List <TrabajosDetalle>();
}