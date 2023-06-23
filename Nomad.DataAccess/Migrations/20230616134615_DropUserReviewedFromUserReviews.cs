using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nomad.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DropUserReviewedFromUserReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersReviews_Users_UserReviewedId",
                table: "UsersReviews");

            migrationBuilder.DropIndex(
                name: "IX_UsersReviews_UserReviewedId",
                table: "UsersReviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UsersReviews_UserReviewedId",
                table: "UsersReviews",
                column: "UserReviewedId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersReviews_Users_UserReviewedId",
                table: "UsersReviews",
                column: "UserReviewedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
