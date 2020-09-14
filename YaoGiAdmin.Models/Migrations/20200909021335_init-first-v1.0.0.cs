using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YaoGiAdmin.Models.Migrations
{
    public partial class initfirstv100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IsDel = table.Column<int>(type: "INT", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    UserAccount = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    UserPassword = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    UserEmail = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    UserMobile = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    UserQQ = table.Column<string>(type: "NVARCHAR(11)", nullable: true),
                    UserWeChat = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    UserBirthday = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    UserGender = table.Column<int>(type: "INT", nullable: false),
                    UserPhoto = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    WebToken = table.Column<string>(type: "NVARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenerateTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    SysUserId = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    IsDel = table.Column<int>(type: "INT", nullable: false),
                    TableName = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    TableCNName = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    Descrption = table.Column<string>(type: "NVARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerateTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerateTables_SysUser_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenerateColumns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    SysUserId = table.Column<Guid>(nullable: true),
                    CreateUser = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    IsDel = table.Column<int>(type: "INT", nullable: false),
                    ColumnName = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    OldColumnName = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    ColumnType = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    OldColumnType = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    GenerateTablesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerateColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerateColumns_GenerateTables_GenerateTablesId",
                        column: x => x.GenerateTablesId,
                        principalTable: "GenerateTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerateColumns_SysUser_SysUserId",
                        column: x => x.SysUserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenerateColumns_GenerateTablesId",
                table: "GenerateColumns",
                column: "GenerateTablesId");

            migrationBuilder.CreateIndex(
                name: "IX_GenerateColumns_SysUserId",
                table: "GenerateColumns",
                column: "SysUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenerateTables_SysUserId",
                table: "GenerateTables",
                column: "SysUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerateColumns");

            migrationBuilder.DropTable(
                name: "GenerateTables");

            migrationBuilder.DropTable(
                name: "SysUser");
        }
    }
}
