using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class updatetblss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_LastrModifierId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "LastrModifierId",
                table: "Brands",
                newName: "LastModifierId");

            migrationBuilder.RenameColumn(
                name: "LasteModifyDate",
                table: "Brands",
                newName: "LastModifyDate");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_LastrModifierId",
                table: "Brands",
                newName: "IX_Brands_LastModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_AspNetUsers_LastModifierId",
                table: "Brands",
                column: "LastModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_LastModifierId",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "LastModifyDate",
                table: "Brands",
                newName: "LasteModifyDate");

            migrationBuilder.RenameColumn(
                name: "LastModifierId",
                table: "Brands",
                newName: "LastrModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_LastModifierId",
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
    }
}
