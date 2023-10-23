using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventos_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsuariosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Age", "BirthDate", "High", "Location", "Name", "Surname1", "Surname2" },
                values: new object[,]
                {
                    { 1, 40, new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local), 180, "Barakaldo", "Ruben", "Zaranton", "Caro" },
                    { 2, 41, new DateTime(1982, 7, 4, 10, 30, 52, 0, DateTimeKind.Local), 185, "Amorebieta", "Unai", "Lara", "" },
                    { 3, 44, new DateTime(1979, 12, 11, 9, 30, 52, 0, DateTimeKind.Local), 160, "Barakaldo", "Marta", "Zaranton", "Caro" },
                    { 4, 46, new DateTime(1977, 5, 6, 10, 30, 52, 0, DateTimeKind.Local), 175, "Barakaldo", "Javier", "Zaranton", "Caro" },
                    { 5, 40, new DateTime(1983, 3, 14, 9, 30, 52, 0, DateTimeKind.Local), 150, "Murcia", "Jaime", "Urrutia", "Gonzalez" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
