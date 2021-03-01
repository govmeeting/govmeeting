using Microsoft.EntityFrameworkCore.Migrations;

namespace GM.Infrastructure.Migrations
{
    public partial class websiteurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Govbodies_GovLocations_ParentLocationId",
                table: "Govbodies");

            migrationBuilder.DropColumn(
                name: "RecordingsUrl",
                table: "GovLocations");

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "GovLocations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentLocationId",
                table: "Govbodies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Govbodies_GovLocations_ParentLocationId",
                table: "Govbodies",
                column: "ParentLocationId",
                principalTable: "GovLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Govbodies_GovLocations_ParentLocationId",
                table: "Govbodies");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "GovLocations");

            migrationBuilder.AddColumn<string>(
                name: "RecordingsUrl",
                table: "GovLocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentLocationId",
                table: "Govbodies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Govbodies_GovLocations_ParentLocationId",
                table: "Govbodies",
                column: "ParentLocationId",
                principalTable: "GovLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
