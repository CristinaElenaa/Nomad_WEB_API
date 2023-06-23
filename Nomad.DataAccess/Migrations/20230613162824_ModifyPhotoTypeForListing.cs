using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPhotoTypeForListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePhoto_Listings_ListingId",
                table: "ProfilePhoto");

            migrationBuilder.DropIndex(
                name: "IX_ProfilePhoto_ListingId",
                table: "ProfilePhoto");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "ProfilePhoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "ProfilePhoto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhoto_ListingId",
                table: "ProfilePhoto",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePhoto_Listings_ListingId",
                table: "ProfilePhoto",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id");
        }
    }
}
