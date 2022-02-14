using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDigikala.Migrations
{
    public partial class spesificationmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificationGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    GroupsId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true),
                    state = table.Column<byte>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<string>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationGroups_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationGroups_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationGroups_AspNetUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SpecificationGroupId = table.Column<int>(nullable: true),
                    state = table.Column<byte>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<string>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_AspNetUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_SpecificationGroups_SpecificationGroupId",
                        column: x => x.SpecificationGroupId,
                        principalTable: "SpecificationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    specificationId = table.Column<int>(nullable: true),
                    state = table.Column<byte>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<string>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationValues_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationValues_AspNetUsers_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecificationValues_Specifications_specificationId",
                        column: x => x.specificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroups_CreatorId",
                table: "SpecificationGroups",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroups_GroupsId",
                table: "SpecificationGroups",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroups_LastModifierId",
                table: "SpecificationGroups",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CreatorId",
                table: "Specifications",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_LastModifierId",
                table: "Specifications",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_SpecificationGroupId",
                table: "Specifications",
                column: "SpecificationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_CreatorId",
                table: "SpecificationValues",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_LastModifierId",
                table: "SpecificationValues",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationValues_specificationId",
                table: "SpecificationValues",
                column: "specificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationValues");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "SpecificationGroups");
        }
    }
}
