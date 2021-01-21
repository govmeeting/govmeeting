using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GM.Infrastructure.Migrations
{
    public partial class AddOfficials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordingsUrl",
                table: "Govbodies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranscriptsUrl",
                table: "Govbodies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointedOfficials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    GovbodyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointedOfficials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointedOfficials_Govbodies_GovbodyId",
                        column: x => x.GovbodyId,
                        principalTable: "Govbodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectedOfficials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    GovbodyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectedOfficials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectedOfficials_Govbodies_GovbodyId",
                        column: x => x.GovbodyId,
                        principalTable: "Govbodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointedOfficials_GovbodyId",
                table: "AppointedOfficials",
                column: "GovbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectedOfficials_GovbodyId",
                table: "ElectedOfficials",
                column: "GovbodyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointedOfficials");

            migrationBuilder.DropTable(
                name: "ElectedOfficials");

            migrationBuilder.DropColumn(
                name: "RecordingsUrl",
                table: "Govbodies");

            migrationBuilder.DropColumn(
                name: "TranscriptsUrl",
                table: "Govbodies");
        }
    }
}
