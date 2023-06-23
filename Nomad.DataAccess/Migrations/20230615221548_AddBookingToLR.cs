using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingToLR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "ListingReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "ListingReviews");
        }
    }
}
