using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GM.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GovLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    ParentLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovLocations_GovLocations_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "GovLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MeetingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Govbodies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    ParentLocationId = table.Column<int>(nullable: false),
                    RecordingsUrl = table.Column<string>(nullable: true),
                    TranscriptsUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Govbodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Govbodies_GovLocations_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "GovLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    GovLocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_GovLocations_GovLocationId",
                        column: x => x.GovLocationId,
                        principalTable: "GovLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointedOfficials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    GovbodyId = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    SourceFilename = table.Column<string>(nullable: true),
                    SourceType = table.Column<int>(nullable: false),
                    WorkStatus = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Govbodies_GovbodyId",
                        column: x => x.GovbodyId,
                        principalTable: "Govbodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    GovbodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledMeeting_Govbodies_GovbodyId",
                        column: x => x.GovbodyId,
                        principalTable: "Govbodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    GovernmentBodyId = table.Column<long>(nullable: false),
                    GovbodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Govbodies_GovbodyId",
                        column: x => x.GovbodyId,
                        principalTable: "Govbodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MeetingId = table.Column<long>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    MeetingId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Meetings_MeetingId1",
                        column: x => x.MeetingId1,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    TopicId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicDiscussions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicId = table.Column<long>(nullable: true),
                    SectionId = table.Column<long>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    SectionId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDiscussions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicDiscussions_Sections_SectionId1",
                        column: x => x.SectionId1,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicDiscussions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(nullable: true),
                    SpeakerId = table.Column<int>(nullable: true),
                    TopicDiscussionId = table.Column<long>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    TopicDiscussionId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talks_Speakers_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talks_TopicDiscussions_TopicDiscussionId1",
                        column: x => x.TopicDiscussionId1,
                        principalTable: "TopicDiscussions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointedOfficials_GovbodyId",
                table: "AppointedOfficials",
                column: "GovbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TopicId",
                table: "Categories",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectedOfficials_GovbodyId",
                table: "ElectedOfficials",
                column: "GovbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Govbodies_ParentLocationId",
                table: "Govbodies",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GovLocations_ParentLocationId",
                table: "GovLocations",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_GovLocationId",
                table: "Languages",
                column: "GovLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_GovbodyId",
                table: "Meetings",
                column: "GovbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMeeting_GovbodyId",
                table: "ScheduledMeeting",
                column: "GovbodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_MeetingId1",
                table: "Sections",
                column: "MeetingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_SpeakerId",
                table: "Talks",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_TopicDiscussionId1",
                table: "Talks",
                column: "TopicDiscussionId1");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDiscussions_SectionId1",
                table: "TopicDiscussions",
                column: "SectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDiscussions_TopicId",
                table: "TopicDiscussions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_GovbodyId",
                table: "Topics",
                column: "GovbodyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointedOfficials");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ElectedOfficials");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ScheduledMeeting");

            migrationBuilder.DropTable(
                name: "Talks");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "TopicDiscussions");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Govbodies");

            migrationBuilder.DropTable(
                name: "GovLocations");
        }
    }
}
