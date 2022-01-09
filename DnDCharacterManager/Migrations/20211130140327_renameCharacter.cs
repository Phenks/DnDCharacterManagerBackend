using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterManager.Migrations
{
    public partial class renameCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterDTOId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CharacterDTOId",
                table: "Items",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CharacterDTOId",
                table: "Items",
                newName: "IX_Items_CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "Items",
                newName: "CharacterDTOId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                newName: "IX_Items_CharacterDTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterDTOId",
                table: "Items",
                column: "CharacterDTOId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
