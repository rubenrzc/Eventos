using Eventos_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace Eventos_API.DataStorage
{
    public class ApplicationDBContext : DbContext
    {
        // Comandos a lanzar para la migracion: add-migration addUsuarios por ejemplo y despues update-database
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasOne(s => s.Evento)
            .WithMany(g => g.Usuarios)
            .HasForeignKey(s => s.EventoId)
            .IsRequired();

            Evento evento = new Evento
            {
                Id = 1,
                Name = "FIESTA"
            };

            //modelBuilder.Entity<Evento>()
            //.HasMany(e => e.Usuarios)
            //.WithOne(e => e.Evento)
            //.HasForeignKey(e => e.Id)
            //.IsRequired();

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Name = "Ruben",
                    Surname1 = "Zaranton",
                    Surname2 = "Caro",
                    Location = "Barakaldo",
                    BirthDate = DateTime.ParseExact("19830314T08:30:52Z", "yyyyMMddTHH:mm:ssZ",
                                System.Globalization.CultureInfo.InvariantCulture),
                    Age = 40,
                    High = 180,
                    EventoId = 1,
                },
                new Usuario
                {
                    Id = 2,
                    Name = "Unai",
                    Surname1 = "Lara",
                    Surname2 = "",
                    Location = "Amorebieta",
                    BirthDate = DateTime.ParseExact("19820704T08:30:52Z", "yyyyMMddTHH:mm:ssZ",
                                System.Globalization.CultureInfo.InvariantCulture),
                    Age = 41,
                    High = 185,
                    EventoId = 1,

                },
                new Usuario
                {
                    Id = 3,
                    Name = "Marta",
                    Surname1 = "Zaranton",
                    Surname2 = "Caro",
                    Location = "Barakaldo",
                    BirthDate = DateTime.ParseExact("19791211T08:30:52Z", "yyyyMMddTHH:mm:ssZ",
                                System.Globalization.CultureInfo.InvariantCulture),
                    Age = 44,
                    High = 160,
                    EventoId = 1,

                },
                new Usuario
                {
                    Id = 4,
                    Name = "Javier",
                    Surname1 = "Zaranton",
                    Surname2 = "Caro",
                    Location = "Barakaldo",
                    BirthDate = DateTime.ParseExact("19770506T08:30:52Z", "yyyyMMddTHH:mm:ssZ",
                                System.Globalization.CultureInfo.InvariantCulture),
                    Age = 46,
                    High = 175,
                    EventoId = 1,

                },
                new Usuario
                {
                    Id = 5,
                    Name = "Jaime",
                    Surname1 = "Urrutia",
                    Surname2 = "Gonzalez",
                    Location = "Murcia",
                    BirthDate = DateTime.ParseExact("19830314T08:30:52Z", "yyyyMMddTHH:mm:ssZ",
                                System.Globalization.CultureInfo.InvariantCulture),
                    Age = 40,
                    High = 150,
                    EventoId = 1,

                }
                );

            modelBuilder.Entity<Evento>().HasData(evento);
        }
    }
}
