﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservasBio.Models
{
    public class Reactivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
