using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersTableWithPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_UserId",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_UserId",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId",
                unique: true);
        }
    }
}
