using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EAVEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EAVEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EAVAttributes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EAVEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EAVAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EAVAttributes_EAVEntities_EAVEntityId",
                        column: x => x.EAVEntityId,
                        principalTable: "EAVEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EAVValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EAVAttributeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EAVValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EAVValues_EAVAttributes_EAVAttributeId",
                        column: x => x.EAVAttributeId,
                        principalTable: "EAVAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EAVAttributes_EAVEntityId",
                table: "EAVAttributes",
                column: "EAVEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EAVValues_EAVAttributeId",
                table: "EAVValues",
                column: "EAVAttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EAVValues");

            migrationBuilder.DropTable(
                name: "EAVAttributes");

            migrationBuilder.DropTable(
                name: "EAVEntities");
        }
    }
}
