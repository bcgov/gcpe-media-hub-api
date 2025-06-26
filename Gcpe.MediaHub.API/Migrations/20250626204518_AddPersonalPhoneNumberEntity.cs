using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonalPhoneNumberEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalPhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaContactId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalPhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalPhoneNumber_MediaContacts_MediaContactId",
                        column: x => x.MediaContactId,
                        principalTable: "MediaContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalPhoneNumber_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalPhoneNumber_MediaContactId",
                table: "PersonalPhoneNumber",
                column: "MediaContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalPhoneNumber_PhoneNumberId",
                table: "PersonalPhoneNumber",
                column: "PhoneNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalPhoneNumber");
        }
    }
}
