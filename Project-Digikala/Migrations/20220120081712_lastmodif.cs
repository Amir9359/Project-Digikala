using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class lastmodif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_LasrModifierId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "LasrModifierId",
                table: "Brands",
                newName: "LastrModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_LasrModifierId",
                table: "Brands",
                newName: "IX_Brands_LastrModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_AspNetUsers_LastrModifierId",
                table: "Brands",
                column: "LastrModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_LastrModifierId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "LastrModifierId",
                table: "Brands",
                newName: "LasrModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_LastrModifierId",
                table: "Brands",
                newName: "IX_Brands_LasrModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_AspNetUsers_LasrModifierId",
                table: "Brands",
                column: "LasrModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
