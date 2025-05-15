using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuilderTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Imie = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nazwisko = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Uprawnienia = table.Column<bool>(type: "boolean", nullable: false),
                    Adres = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Telefon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NIP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    KRS = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NazwaFirmy = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Rola = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Haslo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
