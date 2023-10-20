using Eventos_API.Models.Dtos;

namespace Eventos_API.DataStorage
{
    public static class UsuarioStore
    {
        public static List<UsuarioDTO> GetAll =
                    new List<UsuarioDTO> {
                new UsuarioDTO {
            Id = 1,
            Name = "Ruben",
            Age = 40,
            High = 180,
            },
                new UsuarioDTO {
            Id = 2,
            Name = "Unai",
            Age = 41,
            High= 185
            },

                };

        public static void Save(UsuarioDTO dto)
        {

        }

    }
}