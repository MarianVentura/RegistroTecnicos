using Microsoft.AspNetCore.Antiforgery;

namespace RegistroTecnicos.Models;

public class TiposTecnicos
{
    public int TipoTecnicoId { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

   
}
