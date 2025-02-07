using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreeviewAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeNumber",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonNumber",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EpisodeNumber",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SeasonNumber",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Comments");
        }
    }
}
