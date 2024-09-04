using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "El campo no esta lleno")]
    public string? Nombres { get; set; }

    public int SueldoHora { get; set; }
}
