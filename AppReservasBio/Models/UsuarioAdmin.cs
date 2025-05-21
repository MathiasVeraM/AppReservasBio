using System.ComponentModel.DataAnnotations;

namespace AppReservasBio.Models
{
    public class UsuarioAdmin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
