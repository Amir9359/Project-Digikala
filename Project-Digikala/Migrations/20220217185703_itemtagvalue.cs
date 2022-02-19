using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class itemtagvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_TagValues_TagValueId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_TagValueId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "TagValueId",
                table: "ProductItems");

            migrationBuilder.CreateTable(
                name: "ItemTagValues",
                columns: table => new
                {
                    TagValueId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTagValues", x => new { x.ProductItemId, x.TagValueId });
                    table.ForeignKey(
                        name: "FK_ItemTagValues_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTagValues_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTagValues_TagValues_TagValueId",
                        column: x => x.TagValueId,
                        principalTable: "TagValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagValues_TagId",
                table: "ItemTagValues",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagValues_TagValueId",
                table: "ItemTagValues",
                column: "TagValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTagValues");

            migrationBuilder.AddColumn<int>(
                name: "TagValueId",
                table: "ProductItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_TagValueId",
                table: "ProductItems",
                column: "TagValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_TagValues_TagValueId",
                table: "ProductItems",
                column: "TagValueId",
                principalTable: "TagValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
