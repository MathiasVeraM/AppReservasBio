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

        [Required]
        public string Materia { get; set; }

        [Required]
        public string NombreProyecto { get; set; }

        [Required]
        public string Actividad { get; set; }

        public string ConsideracionesEspeciales { get; set; }

        [Required]
        public int ModuloHorarioId { get; set; }

        [ForeignKey("ModuloHorarioId")]
        public ModuloHorario ModuloHorario { get; set; }

        [Required]
        public int LaboratorioId { get; set; }

        [ForeignKey("LaboratorioId")]
        public Laboratorio Laboratorio { get; set; }

        [Required]
        public int DocenteId { get; set; }

        [ForeignKey("DocenteId")]
        public Docente Docente { get; set; }
        [Required]
        public string EvidenciaCorreoRuta { get; set; } // Ruta de la imagen subida

        public bool Aprobado { get; set; } = false;

        public ICollection<Estudiante> Estudiantes { get; set; }

        public ICollection<Equipo> Equipos { get; set; } // Mesón se incluye como equipo extra

        public ICollection<ReservaReactivo> ReservaReactivos { get; set; }
    }
}
