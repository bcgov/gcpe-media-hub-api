using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcpe.MediaHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addLocationToMediaContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "MediaContacts",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "MediaContacts");
        }
    }
}
