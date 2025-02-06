using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreeviewAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeNumber",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonNumber",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodeNumber",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "SeasonNumber",
                table: "Reviews");
        }
    }
}
