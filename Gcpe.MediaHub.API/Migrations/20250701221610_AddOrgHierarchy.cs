using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOrgHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentOutletId",
                table: "MediaOutlets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutlets_ParentOutletId",
                table: "MediaOutlets",
                column: "ParentOutletId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaOutlets_MediaOutlets_ParentOutletId",
                table: "MediaOutlets",
                column: "ParentOutletId",
                principalTable: "MediaOutlets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaOutlets_MediaOutlets_ParentOutletId",
                table: "MediaOutlets");

            migrationBuilder.DropIndex(
                name: "IX_MediaOutlets_ParentOutletId",
                table: "MediaOutlets");

            migrationBuilder.DropColumn(
                name: "ParentOutletId",
                table: "MediaOutlets");
        }
    }
}
