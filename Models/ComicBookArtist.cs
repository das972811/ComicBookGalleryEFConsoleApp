namespace ComicBookGallery.Models;

public class ComicBookArtist
{
    public int Id { get; set; }
    public int ComicBookId { get; set; }
    public int ArtistId { get; set; }
    public int RoleId { get; set; }

    public ComicBook ComicBook { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
    public Role Role { get; set; } = null!;
}