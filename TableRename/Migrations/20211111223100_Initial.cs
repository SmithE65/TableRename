using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableRename.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity3s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entity2Id = table.Column<int>(type: "int", nullable: false),
                    Entity3Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity1s_Entity2s_Entity2Id",
                        column: x => x.Entity2Id,
                        principalTable: "Entity2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entity1s_Entity3s_Entity3Id",
                        column: x => x.Entity3Id,
                        principalTable: "Entity3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity1s_Entity2Id",
                table: "Entity1s",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Entity1s_Entity3Id",
                table: "Entity1s",
                column: "Entity3Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity1s");

            migrationBuilder.DropTable(
                name: "Entity2s");

            migrationBuilder.DropTable(
                name: "Entity3s");
        }
    }
}
