using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public int ModuloHorarioId { get; set; }

        [ForeignKey("ModuloHorarioId")]
        public ModuloHorario ModuloHorario { get; set; }

        [Required]
        public int LaboratorioId { get; set; }

        [ForeignKey("LaboratorioId")]
        public Laboratorio Laboratorio { get; set; }

        public bool Aprobado { get; set; } = false;

        public ICollection<Estudiante> Estudiantes { get; set; }

        public ICollection<Equipo> Equipos { get; set; }

        public ICollection<ReservaReactivo> ReservaReactivos { get; set; }
    }
}
