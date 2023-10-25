using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos_API.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname1 { get; set; }

        public string? Surname2 { get; set; }

        public string? Location { get; set; }

        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public int High { get; set; }
        
        [ForeignKey("Id")]
        public int EventoId { get; set; }

        [JsonIgnore]
        public Evento? Evento { get; set; }

    }
}
