using Microsoft.EntityFrameworkCore.Migrations;

namespace GM.Infrastructure.Migrations
{
    public partial class AddRecordingUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordingsUrl",
                table: "GovLocations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordingsUrl",
                table: "GovLocations");
        }
    }
}
