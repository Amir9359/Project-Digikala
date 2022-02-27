using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class add_fishnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FishNumber",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PayState",
                table: "Orders",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FishNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PayState",
                table: "Orders");
        }
    }
}
