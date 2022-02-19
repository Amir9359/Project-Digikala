using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class specificationvalue_migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SpecificationValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_ProductId",
                table: "SpecificationValues",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValues_Products_ProductId",
                table: "SpecificationValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValues_Products_ProductId",
                table: "SpecificationValues");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationValues_ProductId",
                table: "SpecificationValues");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SpecificationValues");
        }
    }
}
