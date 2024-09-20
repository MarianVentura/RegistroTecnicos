namespace RegistroTecnicos.Models;

public class Prioridades
{
    public int PrioridadId { get; set; }
    public string? Descripcion { get; set; }
    public TimeSpan Tiempo { get; set; }
}
