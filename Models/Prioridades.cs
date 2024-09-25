using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Prioridades
{
    [Key]
    public int PrioridadId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public TimeSpan Tiempo { get; set; }
}
