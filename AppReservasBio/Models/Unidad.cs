﻿using System.ComponentModel.DataAnnotations;

namespace AppReservasBio.Models
{
    public class Unidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Reactivo> Reactivos { get; set; }
    }
}
