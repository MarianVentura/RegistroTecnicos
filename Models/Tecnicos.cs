using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [Required(ErrorMessage = "El campo no esta lleno")]
    public string? Nombres { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Sueldo por Hora debe ser mayor que cero.")]
    public decimal SueldoHora { get; set; }



    [ForeignKey("TipoTecnico")]
    public int TipoTecnicoId { get; set; }
    public TiposTecnicos? TipoTecnico {  get; set; }

     
}

