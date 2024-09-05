using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "El campo no esta lleno")]
    public string? Nombres { get; set; }

    public decimal SueldoHora { get; set; }

    [ForeignKey("TiposTecnicos")]
    public int TipoTecnicoId { get; set; }
    public TiposTecnicos? TiposTecnicos {  get; set; }

     
}

