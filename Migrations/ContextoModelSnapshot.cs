﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistroTecnicos.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<decimal?>("Costo")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 50m,
                            Descripcion = "Kit de Herramientas Básico",
                            Existencia = 20,
                            Precio = 100m
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 30m,
                            Descripcion = "Multímetro Digital",
                            Existencia = 15,
                            Precio = 70m
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 20m,
                            Descripcion = "Sensor de Movimiento",
                            Existencia = 25,
                            Precio = 45m
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 150m,
                            Descripcion = "Cámara de Seguridad",
                            Existencia = 10,
                            Precio = 300m
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 5m,
                            Descripcion = "Cableado Eléctrico",
                            Existencia = 100,
                            Precio = 15m
                        },
                        new
                        {
                            ArticuloId = 6,
                            Costo = 80m,
                            Descripcion = "Batería de Respaldo",
                            Existencia = 8,
                            Precio = 180m
                        },
                        new
                        {
                            ArticuloId = 7,
                            Costo = 60m,
                            Descripcion = "Fuente de Alimentación",
                            Existencia = 12,
                            Precio = 120m
                        },
                        new
                        {
                            ArticuloId = 8,
                            Costo = 250m,
                            Descripcion = "Panel Solar",
                            Existencia = 5,
                            Precio = 500m
                        },
                        new
                        {
                            ArticuloId = 9,
                            Costo = 90m,
                            Descripcion = "Disco Duro SSD 1TB",
                            Existencia = 10,
                            Precio = 200m
                        },
                        new
                        {
                            ArticuloId = 10,
                            Costo = 40m,
                            Descripcion = "Router Wi-Fi",
                            Existencia = 15,
                            Precio = 100m
                        });
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Property<int>("CotizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CotizacionId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CotizacionId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cotizaciones");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CotizacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("CotizacionId");

                    b.ToTable("CotizacionesDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrioridadId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Tiempo")
                        .HasColumnType("time");

                    b.HasKey("PrioridadId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TecnicoId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SueldoHora")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoTecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoTecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TipoTecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoTecnicoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoTecnicoId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("int");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalle", b =>
                {
                    b.Property<int?>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DetalleId"));

                    b.Property<int?>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal?>("Costo")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Precio")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TrabajosId")
                        .HasColumnType("int");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TrabajosId");

                    b.ToTable("TrabajosDetalle");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.CotizacionesDetalle", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Cotizaciones", "Cotizacion")
                        .WithMany("CotizacionesDetalles")
                        .HasForeignKey("CotizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Cotizacion");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.TiposTecnicos", "TipoTecnico")
                        .WithMany()
                        .HasForeignKey("TipoTecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTecnico");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Prioridades", "Prioridades")
                        .WithMany("Trabajos")
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Tecnicos", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prioridades");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TrabajosDetalle", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId");

                    b.HasOne("RegistroTecnicos.Models.Trabajos", "Trabajos")
                        .WithMany("TrabajosDetalle")
                        .HasForeignKey("TrabajosId");

                    b.Navigation("Articulos");

                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Cotizaciones", b =>
                {
                    b.Navigation("CotizacionesDetalles");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Navigation("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Navigation("TrabajosDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
