using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookGalleryEFConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class SeriesCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeriesTitle",
                table: "ComicBooks");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "ComicBooks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "ComicBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicBooks_SeriesId",
                table: "ComicBooks",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBooks_Series_SeriesId",
                table: "ComicBooks",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBooks_Series_SeriesId",
                table: "ComicBooks");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_ComicBooks_SeriesId",
                table: "ComicBooks");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "ComicBooks");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "ComicBooks");

            migrationBuilder.AddColumn<string>(
                name: "SeriesTitle",
                table: "ComicBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
