using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppReservasBio.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [EmailAddress]
        public string? Correo { get; set; }

        [Required]
        public int ReservaId { get; set; }

        [ForeignKey("ReservaId")]
        public Reserva Reserva { get; set; }
    }
}
