using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class updatetag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTagValues_Tags_TagId",
                table: "ItemTagValues");

            migrationBuilder.DropIndex(
                name: "IX_ItemTagValues_TagId",
                table: "ItemTagValues");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ItemTagValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ItemTagValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagValues_TagId",
                table: "ItemTagValues",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTagValues_Tags_TagId",
                table: "ItemTagValues",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
