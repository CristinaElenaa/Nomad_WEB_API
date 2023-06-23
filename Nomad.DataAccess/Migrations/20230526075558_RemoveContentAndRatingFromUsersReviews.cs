using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContentAndRatingFromUsersReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "UsersReviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UsersReviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "UsersReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "UsersReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
