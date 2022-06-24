using Microsoft.EntityFrameworkCore.Migrations;

namespace Kino.Migrations
{
    public partial class AddcienmaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Films",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Cinemas_CinemaId",
                table: "Films",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
