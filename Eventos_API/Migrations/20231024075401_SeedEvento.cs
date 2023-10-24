using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventos_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    High = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "FIESTA" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Age", "BirthDate", "EventoId", "High", "Location", "Name", "Surname1", "Surname2" },
                values: new object[,]
                {
                    { 1, 40, new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local), 1, 180, "Barakaldo", "Ruben", "Zaranton", "Caro" },
                    { 2, 41, new DateTime(1982, 7, 4, 10, 30, 52, 0, DateTimeKind.Local), 1, 185, "Amorebieta", "Unai", "Lara", "" },
                    { 3, 44, new DateTime(1979, 12, 11, 9, 30, 52, 0, DateTimeKind.Local), 1, 160, "Barakaldo", "Marta", "Zaranton", "Caro" },
                    { 4, 46, new DateTime(1977, 5, 6, 10, 30, 52, 0, DateTimeKind.Local), 1, 175, "Barakaldo", "Javier", "Zaranton", "Caro" },
                    { 5, 40, new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local), 1, 150, "Murcia", "Jaime", "Urrutia", "Gonzalez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EventoId",
                table: "Usuarios",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
