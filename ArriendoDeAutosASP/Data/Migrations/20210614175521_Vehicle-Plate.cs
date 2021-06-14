using Microsoft.EntityFrameworkCore.Migrations;

namespace ArriendoDeAutosASP.Data.Migrations
{
    public partial class VehiclePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LiscensePlate",
                table: "Vehicle",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiscensePlate",
                table: "Vehicle");
        }
    }
}
