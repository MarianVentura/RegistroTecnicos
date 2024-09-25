using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El número de WhatsApp es obligatorio.")]
    [Phone(ErrorMessage = "El número de WhatsApp no es válido.")]
    public string? WhatsApp { get; set; }


}