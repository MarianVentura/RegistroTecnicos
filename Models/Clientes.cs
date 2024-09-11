using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClientesId { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Este campo solo debe contener letras.")]
    public string? NombresClientes { get; set; }

    [Required(ErrorMessage = "El número de WhatsApp es obligatorio.")]
    [Phone(ErrorMessage = "El número de WhatsApp no es válido.")]
    public string? WhatsApp { get; set; }


}
