using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookGalleryEFConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class ArtistsComicBookManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistComicBook",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    ComicBooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistComicBook", x => new { x.ArtistsId, x.ComicBooksId });
                    table.ForeignKey(
                        name: "FK_ArtistComicBook_Artist_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistComicBook_ComicBooks_ComicBooksId",
                        column: x => x.ComicBooksId,
                        principalTable: "ComicBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistComicBook_ComicBooksId",
                table: "ArtistComicBook",
                column: "ComicBooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistComicBook");

            migrationBuilder.DropTable(
                name: "Artist");
        }
    }
}
