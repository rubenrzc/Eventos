﻿// <auto-generated />
using System;
using Eventos_API.DataStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eventos_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20231025072554_ModificarDto2")]
    partial class ModificarDto2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eventos_API.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "FIESTA"
                        });
                });

            modelBuilder.Entity("Eventos_API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("High")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 40,
                            BirthDate = new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local),
                            EventoId = 1,
                            High = 180,
                            Location = "Barakaldo",
                            Name = "Ruben",
                            Surname1 = "Zaranton",
                            Surname2 = "Caro"
                        },
                        new
                        {
                            Id = 2,
                            Age = 41,
                            BirthDate = new DateTime(1982, 7, 4, 10, 30, 52, 0, DateTimeKind.Local),
                            EventoId = 1,
                            High = 185,
                            Location = "Amorebieta",
                            Name = "Unai",
                            Surname1 = "Lara",
                            Surname2 = ""
                        },
                        new
                        {
                            Id = 3,
                            Age = 44,
                            BirthDate = new DateTime(1979, 12, 11, 9, 30, 52, 0, DateTimeKind.Local),
                            EventoId = 1,
                            High = 160,
                            Location = "Barakaldo",
                            Name = "Marta",
                            Surname1 = "Zaranton",
                            Surname2 = "Caro"
                        },
                        new
                        {
                            Id = 4,
                            Age = 46,
                            BirthDate = new DateTime(1977, 5, 6, 10, 30, 52, 0, DateTimeKind.Local),
                            EventoId = 1,
                            High = 175,
                            Location = "Barakaldo",
                            Name = "Javier",
                            Surname1 = "Zaranton",
                            Surname2 = "Caro"
                        },
                        new
                        {
                            Id = 5,
                            Age = 40,
                            BirthDate = new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local),
                            EventoId = 1,
                            High = 150,
                            Location = "Murcia",
                            Name = "Jaime",
                            Surname1 = "Urrutia",
                            Surname2 = "Gonzalez"
                        });
                });

            modelBuilder.Entity("Eventos_API.Models.Usuario", b =>
                {
                    b.HasOne("Eventos_API.Models.Evento", "Evento")
                        .WithMany("Usuarios")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("Eventos_API.Models.Evento", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
