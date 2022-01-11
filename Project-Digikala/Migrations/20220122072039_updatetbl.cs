using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class updatetbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_LasrModifierId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_LasrModifierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_keypoint_stateId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "keypoint");

            migrationBuilder.DropIndex(
                name: "IX_Products_stateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "stateId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LasteModifyDate",
                table: "Products",
                newName: "LastModifyDate");

            migrationBuilder.RenameColumn(
                name: "LasrModifierId",
                table: "Products",
                newName: "LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LasrModifierId",
                table: "Products",
                newName: "IX_Products_LastModifierId");

            migrationBuilder.RenameColumn(
                name: "LasteModifyDate",
                table: "Groups",
                newName: "LastModifyDate");

            migrationBuilder.RenameColumn(
                name: "LasrModifierId",
                table: "Groups",
                newName: "LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_LasrModifierId",
                table: "Groups",
                newName: "IX_Groups_LastModifierId");

            migrationBuilder.AddColumn<byte>(
                name: "state",
                table: "Products",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_LastModifierId",
                table: "Groups",
                column: "LastModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_LastModifierId",
                table: "Products",
                column: "LastModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_LastModifierId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_LastModifierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LastModifyDate",
                table: "Products",
                newName: "LasteModifyDate");

            migrationBuilder.RenameColumn(
                name: "LastModifierId",
                table: "Products",
                newName: "LasrModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LastModifierId",
                table: "Products",
                newName: "IX_Products_LasrModifierId");

            migrationBuilder.RenameColumn(
                name: "LastModifyDate",
                table: "Groups",
                newName: "LasteModifyDate");

            migrationBuilder.RenameColumn(
                name: "LastModifierId",
                table: "Groups",
                newName: "LasrModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_LastModifierId",
                table: "Groups",
                newName: "IX_Groups_LasrModifierId");

            migrationBuilder.AddColumn<int>(
                name: "stateId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "keypoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    LasrModifierId = table.Column<string>(nullable: true),
                    LasteModifyDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keypoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_keypoint_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_keypoint_AspNetUsers_LasrModifierId",
                        column: x => x.LasrModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_stateId",
                table: "Products",
                column: "stateId");

            migrationBuilder.CreateIndex(
                name: "IX_keypoint_CreatorId",
                table: "keypoint",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_keypoint_LasrModifierId",
                table: "keypoint",
                column: "LasrModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_LasrModifierId",
                table: "Groups",
                column: "LasrModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_LasrModifierId",
                table: "Products",
                column: "LasrModifierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_keypoint_stateId",
                table: "Products",
                column: "stateId",
                principalTable: "keypoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
