using Eventos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos_API.DataStorage
{
    public class ApplicationDBContext: DbContext
    {
        // Comandos a lanzar para la migracion: add-migration addUsuarios por ejemplo y despues update-database
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
