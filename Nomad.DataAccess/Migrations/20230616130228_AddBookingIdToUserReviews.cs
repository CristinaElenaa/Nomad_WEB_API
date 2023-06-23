using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingIdToUserReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "UsersReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "UsersReviews");
        }
    }
}
