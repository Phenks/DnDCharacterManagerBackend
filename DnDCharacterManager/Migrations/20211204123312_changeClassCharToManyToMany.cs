using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterManager.Migrations
{
    public partial class changeClassCharToManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Characters_CharacterId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CharacterId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Classes");

            migrationBuilder.CreateTable(
                name: "CharacterCharacterClass",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCharacterClass", x => new { x.CharactersId, x.ClassesId });
                    table.ForeignKey(
                        name: "FK_CharacterCharacterClass_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCharacterClass_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCharacterClass_ClassesId",
                table: "CharacterCharacterClass",
                column: "ClassesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterCharacterClass");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Classes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CharacterId",
                table: "Classes",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Characters_CharacterId",
                table: "Classes",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
