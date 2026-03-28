using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolVote.API.Migrations
{
    /// <inheritdoc />
    public partial class AddVotingSessionToVoters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_VotingSessions_VotingSessionsId",
                table: "Voters");

            migrationBuilder.DropIndex(
                name: "IX_Voters_VotingSessionsId",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "VotingSessionsId",
                table: "Voters");

            migrationBuilder.AddColumn<int>(
                name: "FemaleVotes",
                table: "Voters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleVotes",
                table: "Voters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VotingSessionId",
                table: "Voters",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Voters_VotingSessionId",
                table: "Voters",
                column: "VotingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_VotingSessions_VotingSessionId",
                table: "Voters",
                column: "VotingSessionId",
                principalTable: "VotingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_VotingSessions_VotingSessionId",
                table: "Voters");

            migrationBuilder.DropIndex(
                name: "IX_Voters_VotingSessionId",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "FemaleVotes",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "MaleVotes",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "VotingSessionId",
                table: "Voters");

            migrationBuilder.AddColumn<Guid>(
                name: "VotingSessionsId",
                table: "Voters",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voters_VotingSessionsId",
                table: "Voters",
                column: "VotingSessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_VotingSessions_VotingSessionsId",
                table: "Voters",
                column: "VotingSessionsId",
                principalTable: "VotingSessions",
                principalColumn: "Id");
        }
    }
}
