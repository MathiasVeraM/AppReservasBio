using AppReservasBio.Models;
using Microsoft.EntityFrameworkCore;

namespace AppReservasBio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tablas (DbSets)
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<ModuloHorario> ModulosHorario { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Reactivo> Reactivos { get; set; }
        public DbSet<UsuarioAdmin> UsuariosAdmin { get; set; }
        public DbSet<ReservaReactivo> ReservaReactivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones: Estudiante -> Reserva (uno a muchos)
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Reserva)
                .WithMany(r => r.Estudiantes)
                .HasForeignKey(e => e.ReservaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Reserva <-> Equipos (muchos a muchos)
            modelBuilder.Entity<Reserva>()
                .HasMany(r => r.Equipos)
                .WithMany();

            // Relación Reserva <-> Reactivos (muchos a muchos)
            modelBuilder.Entity<ReservaReactivo>()
                .HasOne(rr => rr.Reserva)
                .WithMany(r => r.ReservaReactivos)
                .HasForeignKey(rr => rr.ReservaId);

            modelBuilder.Entity<ReservaReactivo>()
                .HasOne(rr => rr.Reactivo)
                .WithMany()
                .HasForeignKey(rr => rr.ReactivoId);

            // Datos de ejemplo para módulos (opcional)
            modelBuilder.Entity<ModuloHorario>().HasData(
                    new ModuloHorario { Id = 1, Nombre = "07:00 - 08:00", HoraInicio = new TimeSpan(7, 0, 0), HoraFin = new TimeSpan(8, 0, 0) },
                    new ModuloHorario { Id = 2, Nombre = "08:05 - 09:05", HoraInicio = new TimeSpan(8, 5, 0), HoraFin = new TimeSpan(9, 5, 0) },
                    new ModuloHorario { Id = 3, Nombre = "09:10 - 10:10", HoraInicio = new TimeSpan(9, 10, 0), HoraFin = new TimeSpan(10, 10, 0) },
                    new ModuloHorario { Id = 4, Nombre = "10:15 - 11:15", HoraInicio = new TimeSpan(10, 15, 0), HoraFin = new TimeSpan(11, 15, 0) },
                    new ModuloHorario { Id = 5, Nombre = "11:20 - 12:20", HoraInicio = new TimeSpan(11, 20, 0), HoraFin = new TimeSpan(12, 20, 0) },
                    new ModuloHorario { Id = 6, Nombre = "12:25 - 13:25", HoraInicio = new TimeSpan(12, 25, 0), HoraFin = new TimeSpan(13, 25, 0) },
                    new ModuloHorario { Id = 7, Nombre = "13:30 - 14:30", HoraInicio = new TimeSpan(13, 30, 0), HoraFin = new TimeSpan(14, 30, 0) },
                    new ModuloHorario { Id = 8, Nombre = "14:35 - 15:35", HoraInicio = new TimeSpan(14, 35, 0), HoraFin = new TimeSpan(15, 35, 0) },
                    new ModuloHorario { Id = 9, Nombre = "15:40 - 16:40", HoraInicio = new TimeSpan(15, 40, 0), HoraFin = new TimeSpan(16, 40, 0) },
                    new ModuloHorario { Id = 10, Nombre = "16:45 - 17:45", HoraInicio = new TimeSpan(16, 45, 0), HoraFin = new TimeSpan(17, 45, 0) },
                    new ModuloHorario { Id = 11, Nombre = "17:50 - 18:50", HoraInicio = new TimeSpan(17, 50, 0), HoraFin = new TimeSpan(18, 50, 0) }
            );
        }
    }
}
