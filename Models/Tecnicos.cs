using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "El campo no esta lleno")]
    public string? Nombres { get; set; }

    public decimal SueldoHora { get; set; }
}

public class TipoTecnico
{
    public int TipoTecnicoId { get; set; }
    public string? Descripcion { get; set; }
}