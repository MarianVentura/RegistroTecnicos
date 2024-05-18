using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Tecnico
    {
        public int TecnicoId { get; set; }
        public string? Nombres { get; set; }
        public decimal SueldoHora { get; set; }
        public int TipoId { get; set; }
        public TipoTecnico? Tipo { get; set; }


    }
}
