using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMultipleMediaOutletPhoneNumbers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaOutletPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaOutletPhoneTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MediaOutletId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaOutletPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaOutletPhoneNumbers_MediaOutletPhoneTypes_MediaOutletPhoneTypeId",
                        column: x => x.MediaOutletPhoneTypeId,
                        principalTable: "MediaOutletPhoneTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MediaOutletPhoneNumbers_MediaOutlets_MediaOutletId",
                        column: x => x.MediaOutletId,
                        principalTable: "MediaOutlets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletPhoneNumbers_MediaOutletId",
                table: "MediaOutletPhoneNumbers",
                column: "MediaOutletId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaOutletPhoneNumbers_MediaOutletPhoneTypeId",
                table: "MediaOutletPhoneNumbers",
                column: "MediaOutletPhoneTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaOutletPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");
        }
    }
}
