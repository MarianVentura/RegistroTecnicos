using Microsoft.EntityFrameworkCore;
using RegistrodeTecnicos.Models;

namespace RegistroTecnicos.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<TipoTecnicos> TipoTecnicos { get; set; }
     
    }
}
