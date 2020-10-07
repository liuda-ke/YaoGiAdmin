using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YaoGiAdmin.Models.Migrations
{
    public partial class initfirstv101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenerateColumns_GenerateTables_GenerateTablesId",
                table: "GenerateColumns");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenerateTablesId",
                table: "GenerateColumns",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColumnCnName",
                table: "GenerateColumns",
                type: "NVARCHAR(200)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenerateColumns_GenerateTables_GenerateTablesId",
                table: "GenerateColumns",
                column: "GenerateTablesId",
                principalTable: "GenerateTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenerateColumns_GenerateTables_GenerateTablesId",
                table: "GenerateColumns");

            migrationBuilder.DropColumn(
                name: "ColumnCnName",
                table: "GenerateColumns");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenerateTablesId",
                table: "GenerateColumns",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_GenerateColumns_GenerateTables_GenerateTablesId",
                table: "GenerateColumns",
                column: "GenerateTablesId",
                principalTable: "GenerateTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
