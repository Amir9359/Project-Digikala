using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class add_state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_MyPropertyId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "Products",
                newName: "brandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_MyPropertyId",
                table: "Products",
                newName: "IX_Products_brandId");

            migrationBuilder.AddColumn<byte>(
                name: "state",
                table: "Groups",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "state",
                table: "Brands",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products",
                column: "brandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "brandId",
                table: "Products",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_brandId",
                table: "Products",
                newName: "IX_Products_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_MyPropertyId",
                table: "Products",
                column: "MyPropertyId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
