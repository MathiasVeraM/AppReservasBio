using System.ComponentModel.DataAnnotations;

namespace AppReservasBio.Models
{
    public class ModuloHorario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
