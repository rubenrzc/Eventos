using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Eventos_API.Models.Dtos
{
    public class EventoDTO
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public ICollection<UsuarioDTO> Usuarios = new List<UsuarioDTO>();
    }
}
