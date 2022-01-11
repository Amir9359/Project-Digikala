using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class keypoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Groups_groupId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "groupId",
                table: "Products",
                newName: "groupid");

            migrationBuilder.RenameColumn(
                name: "brandId",
                table: "Products",
                newName: "brandid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_groupId",
                table: "Products",
                newName: "IX_Products_groupid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_brandId",
                table: "Products",
                newName: "IX_Products_brandid");

            migrationBuilder.AlterColumn<int>(
                name: "groupid",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "brandid",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "keypoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    type = table.Column<byte>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<string>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keypoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_keypoints_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_keypoints_AspNetUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_keypoints_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_keypoints_CreatorId",
                table: "keypoints",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_keypoints_LastModifierId",
                table: "keypoints",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_keypoints_ProductId",
                table: "keypoints",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandid",
                table: "Products",
                column: "brandid",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Groups_groupid",
                table: "Products",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_brandid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Groups_groupid",
                table: "Products");

            migrationBuilder.DropTable(
                name: "keypoints");

            migrationBuilder.RenameColumn(
                name: "groupid",
                table: "Products",
                newName: "groupId");

            migrationBuilder.RenameColumn(
                name: "brandid",
                table: "Products",
                newName: "brandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_groupid",
                table: "Products",
                newName: "IX_Products_groupId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_brandid",
                table: "Products",
                newName: "IX_Products_brandId");

            migrationBuilder.AlterColumn<int>(
                name: "groupId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "brandId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_brandId",
                table: "Products",
                column: "brandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Groups_groupId",
                table: "Products",
                column: "groupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
