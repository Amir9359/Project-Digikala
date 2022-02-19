using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class productitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: true),
                    Quantity = table.Column<byte>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    TagValueId = table.Column<int>(nullable: true),
                    state = table.Column<byte>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<string>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItems_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_AspNetUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductItems_TagValues_TagValueId",
                        column: x => x.TagValueId,
                        principalTable: "TagValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_CreatorId",
                table: "ProductItems",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_LastModifierId",
                table: "ProductItems",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductId",
                table: "ProductItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_TagValueId",
                table: "ProductItems",
                column: "TagValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItems");
        }
    }
}
