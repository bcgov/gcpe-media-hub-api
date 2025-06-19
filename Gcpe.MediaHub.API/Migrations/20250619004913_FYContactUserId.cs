using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class FYContactUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FYIContactUserId",
                table: "MediaRequests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaRequests_FYIContactUserId",
                table: "MediaRequests",
                column: "FYIContactUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaRequests_Users_FYIContactUserId",
                table: "MediaRequests",
                column: "FYIContactUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaRequests_Users_FYIContactUserId",
                table: "MediaRequests");

            migrationBuilder.DropIndex(
                name: "IX_MediaRequests_FYIContactUserId",
                table: "MediaRequests");

            migrationBuilder.DropColumn(
                name: "FYIContactUserId",
                table: "MediaRequests");
        }
    }
}
