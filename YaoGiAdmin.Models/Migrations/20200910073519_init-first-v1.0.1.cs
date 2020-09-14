using Microsoft.EntityFrameworkCore.Migrations;

namespace YaoGiAdmin.Models.Migrations
{
    public partial class initfirstv101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsGenerate",
                table: "GenerateTables",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGenerate",
                table: "GenerateTables");
        }
    }
}
