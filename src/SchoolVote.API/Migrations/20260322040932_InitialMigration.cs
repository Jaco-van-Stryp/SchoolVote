using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolVote.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotingSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VotingSessionName = table.Column<string>(type: "text", nullable: false),
                    AdministratorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingSessions_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nominations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    GradeAllocated = table.Column<int>(type: "integer", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: false),
                    VotingSessionsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nominations_VotingSessions_VotingSessionsId",
                        column: x => x.VotingSessionsId,
                        principalTable: "VotingSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthKey = table.Column<string>(type: "text", nullable: false),
                    AuthName = table.Column<string>(type: "text", nullable: false),
                    AuthorizedGrade = table.Column<int>(type: "integer", nullable: false),
                    Voted = table.Column<bool>(type: "boolean", nullable: false),
                    VotingSessionsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voters_VotingSessions_VotingSessionsId",
                        column: x => x.VotingSessionsId,
                        principalTable: "VotingSessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VotesCasted",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VotingSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoterId = table.Column<Guid>(type: "uuid", nullable: false),
                    NominatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateVoted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotesCasted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotesCasted_Nominations_NominatedId",
                        column: x => x.NominatedId,
                        principalTable: "Nominations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotesCasted_Voters_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Voters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotesCasted_VotingSessions_VotingSessionId",
                        column: x => x.VotingSessionId,
                        principalTable: "VotingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nominations_VotingSessionsId",
                table: "Nominations",
                column: "VotingSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_VotingSessionsId",
                table: "Voters",
                column: "VotingSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_VotesCasted_NominatedId",
                table: "VotesCasted",
                column: "NominatedId");

            migrationBuilder.CreateIndex(
                name: "IX_VotesCasted_VoterId",
                table: "VotesCasted",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_VotesCasted_VotingSessionId",
                table: "VotesCasted",
                column: "VotingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingSessions_AdministratorId",
                table: "VotingSessions",
                column: "AdministratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotesCasted");

            migrationBuilder.DropTable(
                name: "Nominations");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "VotingSessions");

            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
