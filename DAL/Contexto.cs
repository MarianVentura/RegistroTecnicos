using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<TiposTecnicos> TiposTecnicos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Trabajos> Trabajos { get; set; }
    public DbSet<Prioridades> Prioridades { get; set; }

    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<TrabajosDetalle> TrabajosDetalle { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   
        modelBuilder.Entity<Articulos>().HasData(
            new Articulos { ArticuloId = 1, Descripcion = "Kit de Herramientas Básico", Costo = 50m, Precio = 100m, Existencia = 20 },
            new Articulos { ArticuloId = 2, Descripcion = "Multímetro Digital", Costo = 30m, Precio = 70m, Existencia = 15 },
            new Articulos { ArticuloId = 3, Descripcion = "Sensor de Movimiento", Costo = 20m, Precio = 45m, Existencia = 25 },
            new Articulos { ArticuloId = 4, Descripcion = "Cámara de Seguridad", Costo = 150m, Precio = 300m, Existencia = 10 },
            new Articulos { ArticuloId = 5, Descripcion = "Cableado Eléctrico", Costo = 5m, Precio = 15m, Existencia = 100 },
            new Articulos { ArticuloId = 6, Descripcion = "Batería de Respaldo", Costo = 80m, Precio = 180m, Existencia = 8 },
            new Articulos { ArticuloId = 7, Descripcion = "Fuente de Alimentación", Costo = 60m, Precio = 120m, Existencia = 12 },
            new Articulos { ArticuloId = 8, Descripcion = "Panel Solar", Costo = 250m, Precio = 500m, Existencia = 5 },
            new Articulos { ArticuloId = 9, Descripcion = "Disco Duro SSD 1TB", Costo = 90m, Precio = 200m, Existencia = 10 },
            new Articulos { ArticuloId = 10, Descripcion = "Router Wi-Fi", Costo = 40m, Precio = 100m, Existencia = 15 }
        );

        base.OnModelCreating(modelBuilder);

    }
}


