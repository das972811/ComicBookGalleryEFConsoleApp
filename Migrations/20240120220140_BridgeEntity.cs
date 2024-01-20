using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookGalleryEFConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class BridgeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistComicBook");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ComicBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComicBookArtist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComicBookId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicBookArtist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicBookArtist_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicBookArtist_ComicBooks_ComicBookId",
                        column: x => x.ComicBookId,
                        principalTable: "ComicBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicBookArtist_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicBooks_ArtistId",
                table: "ComicBooks",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicBookArtist_ArtistId",
                table: "ComicBookArtist",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicBookArtist_ComicBookId",
                table: "ComicBookArtist",
                column: "ComicBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicBookArtist_RoleId",
                table: "ComicBookArtist",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBooks_Artist_ArtistId",
                table: "ComicBooks",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBooks_Artist_ArtistId",
                table: "ComicBooks");

            migrationBuilder.DropTable(
                name: "ComicBookArtist");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_ComicBooks_ArtistId",
                table: "ComicBooks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ComicBooks");

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
    }
}
