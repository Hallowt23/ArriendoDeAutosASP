using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendoDeAutosASP.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "HP",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rental");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Rental",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Rental",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Liscense = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Client_Id",
                table: "Rental",
                column: "Id",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Client_Id",
                table: "Rental");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Rental");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Rental",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HP",
                table: "Rental",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rut",
                table: "Rental",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Rental",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
