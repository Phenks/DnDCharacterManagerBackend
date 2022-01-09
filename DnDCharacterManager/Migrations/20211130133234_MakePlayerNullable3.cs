using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterManager.Migrations
{
    public partial class MakePlayerNullable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_PlayerId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Characters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_PlayerId",
                table: "Characters",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_PlayerId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_PlayerId",
                table: "Characters",
                column: "PlayerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
