using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class InitMigration_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDiffuculty_WalkDiffucultyId",
                table: "Walks");

            migrationBuilder.DropTable(
                name: "WalkDiffuculty");

            migrationBuilder.DropIndex(
                name: "IX_Walks_WalkDiffucultyId",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "WalkDiffucultyId",
                table: "Walks");

            migrationBuilder.CreateTable(
                name: "WalkDifficulty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDifficulty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDifficulty_WalkDifficultyId",
                table: "Walks",
                column: "WalkDifficultyId",
                principalTable: "WalkDifficulty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_WalkDifficulty_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.DropTable(
                name: "WalkDifficulty");

            migrationBuilder.DropIndex(
                name: "IX_Walks_WalkDifficultyId",
                table: "Walks");

            migrationBuilder.AddColumn<Guid>(
                name: "WalkDiffucultyId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WalkDiffuculty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkDiffuculty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkDiffucultyId",
                table: "Walks",
                column: "WalkDiffucultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_WalkDiffuculty_WalkDiffucultyId",
                table: "Walks",
                column: "WalkDiffucultyId",
                principalTable: "WalkDiffuculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
