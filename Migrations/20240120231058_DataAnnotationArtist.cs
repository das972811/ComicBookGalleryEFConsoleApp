using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComicBookGalleryEFConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotationArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBookArtist_Artist_ArtistId",
                table: "ComicBookArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_ComicBooks_Artist_ArtistId",
                table: "ComicBooks");

            migrationBuilder.DropIndex(
                name: "IX_ComicBooks_ArtistId",
                table: "ComicBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ComicBooks");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Talent");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Talent",
                newName: "FullName");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Talent",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Talent",
                table: "Talent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBookArtist_Talent_ArtistId",
                table: "ComicBookArtist",
                column: "ArtistId",
                principalTable: "Talent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicBookArtist_Talent_ArtistId",
                table: "ComicBookArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Talent",
                table: "Talent");

            migrationBuilder.RenameTable(
                name: "Talent",
                newName: "Artist");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Artist",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ComicBooks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ComicBooks_ArtistId",
                table: "ComicBooks",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBookArtist_Artist_ArtistId",
                table: "ComicBookArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComicBooks_Artist_ArtistId",
                table: "ComicBooks",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id");
        }
    }
}
