﻿// <auto-generated />
using System;
using AppReservasBio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppReservasBio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250515184555_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppReservasBio.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("AppReservasBio.Models.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("AppReservasBio.Models.Laboratorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Laboratorios");
                });

            modelBuilder.Entity("AppReservasBio.Models.ModuloHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModulosHorario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HoraFin = new TimeSpan(0, 8, 0, 0, 0),
                            HoraInicio = new TimeSpan(0, 7, 0, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 2,
                            HoraFin = new TimeSpan(0, 9, 5, 0, 0),
                            HoraInicio = new TimeSpan(0, 8, 5, 0, 0),
                            Nombre = "08:05 - 09:05"
                        },
                        new
                        {
                            Id = 3,
                            HoraFin = new TimeSpan(0, 10, 10, 0, 0),
                            HoraInicio = new TimeSpan(0, 9, 10, 0, 0),
                            Nombre = "09:10 - 10:10"
                        },
                        new
                        {
                            Id = 4,
                            HoraFin = new TimeSpan(0, 11, 15, 0, 0),
                            HoraInicio = new TimeSpan(0, 10, 15, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 5,
                            HoraFin = new TimeSpan(0, 12, 20, 0, 0),
                            HoraInicio = new TimeSpan(0, 11, 20, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 6,
                            HoraFin = new TimeSpan(0, 13, 25, 0, 0),
                            HoraInicio = new TimeSpan(0, 12, 25, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 7,
                            HoraFin = new TimeSpan(0, 14, 30, 0, 0),
                            HoraInicio = new TimeSpan(0, 13, 30, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 8,
                            HoraFin = new TimeSpan(0, 15, 35, 0, 0),
                            HoraInicio = new TimeSpan(0, 14, 35, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 9,
                            HoraFin = new TimeSpan(0, 16, 40, 0, 0),
                            HoraInicio = new TimeSpan(0, 15, 40, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 10,
                            HoraFin = new TimeSpan(0, 17, 45, 0, 0),
                            HoraInicio = new TimeSpan(0, 16, 45, 0, 0),
                            Nombre = "07:00 - 08:00"
                        },
                        new
                        {
                            Id = 11,
                            HoraFin = new TimeSpan(0, 18, 50, 0, 0),
                            HoraInicio = new TimeSpan(0, 17, 50, 0, 0),
                            Nombre = "07:00 - 08:00"
                        });
                });

            modelBuilder.Entity("AppReservasBio.Models.Reactivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reactivos");
                });

            modelBuilder.Entity("AppReservasBio.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("LaboratorioId")
                        .HasColumnType("int");

                    b.Property<int>("ModuloHorarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorioId");

                    b.HasIndex("ModuloHorarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("EquipoReserva", b =>
                {
                    b.Property<int>("EquiposId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("EquiposId", "ReservaId");

                    b.HasIndex("ReservaId");

                    b.ToTable("EquipoReserva");
                });

            modelBuilder.Entity("ReactivoReserva", b =>
                {
                    b.Property<int>("ReactivosId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("ReactivosId", "ReservaId");

                    b.HasIndex("ReservaId");

                    b.ToTable("ReactivoReserva");
                });

            modelBuilder.Entity("AppReservasBio.Models.Estudiante", b =>
                {
                    b.HasOne("AppReservasBio.Models.Reserva", "Reserva")
                        .WithMany("Estudiantes")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("AppReservasBio.Models.Reserva", b =>
                {
                    b.HasOne("AppReservasBio.Models.Laboratorio", "Laboratorio")
                        .WithMany("Reservas")
                        .HasForeignKey("LaboratorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppReservasBio.Models.ModuloHorario", "ModuloHorario")
                        .WithMany("Reservas")
                        .HasForeignKey("ModuloHorarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratorio");

                    b.Navigation("ModuloHorario");
                });

            modelBuilder.Entity("EquipoReserva", b =>
                {
                    b.HasOne("AppReservasBio.Models.Equipo", null)
                        .WithMany()
                        .HasForeignKey("EquiposId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppReservasBio.Models.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactivoReserva", b =>
                {
                    b.HasOne("AppReservasBio.Models.Reactivo", null)
                        .WithMany()
                        .HasForeignKey("ReactivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppReservasBio.Models.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppReservasBio.Models.Laboratorio", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("AppReservasBio.Models.ModuloHorario", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("AppReservasBio.Models.Reserva", b =>
                {
                    b.Navigation("Estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
