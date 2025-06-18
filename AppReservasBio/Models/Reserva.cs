using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AppReservasBio.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string? Materia { get; set; }
        public string? NombreProyecto { get; set; }
        public string? Actividad { get; set; }
        public string? ConsideracionesEspeciales { get; set; }

        public int? ModuloHorarioId { get; set; }
        public ModuloHorario? ModuloHorario { get; set; }

        public int LaboratorioId { get; set; }
        public Laboratorio Laboratorio { get; set; }

        public int? DocenteId { get; set; }
        public Docente? Docente { get; set; }

        public string? EvidenciaCorreoRuta { get; set; }

        public bool Aprobado { get; set; } = false;

        public bool EsMantenimiento { get; set; } = false;
        public TimeSpan? HoraInicioMantenimiento { get; set; }
        public TimeSpan? HoraFinMantenimiento { get; set; }

        public string? UsuarioId { get; set; }

        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
        public ICollection<ReservaReactivo> ReservaReactivos { get; set; } = new List<ReservaReactivo>();
    }
}
