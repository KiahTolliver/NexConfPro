using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextConfPro.Services.EventAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEventToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Location", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Location 1", "The Best Conference Ever", new DateTime(2024, 1, 17, 10, 30, 41, 239, DateTimeKind.Local).AddTicks(5250) },
                    { 2, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Location 2", "The Second Best Conference Ever", new DateTime(2024, 1, 17, 10, 30, 41, 239, DateTimeKind.Local).AddTicks(5290) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
