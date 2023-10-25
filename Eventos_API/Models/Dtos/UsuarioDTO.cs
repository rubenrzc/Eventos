﻿using System.ComponentModel.DataAnnotations;

namespace Eventos_API.Models.Dtos
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public required string Name { get; set; }

        public required string Surname1 { get; set; }

        public string? Surname2 { get; set; }

        public string? Location { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age{ get; set; }

        public int High{ get; set; }

        public int EventoId { get; set; }
    }
}
