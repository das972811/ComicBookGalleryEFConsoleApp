namespace ComicBookGallery.Models;

public class ComicBookArtist
{
    public int Id { get; set; }
    public int ComicBookId { get; set; }
    public int ArtistId { get; set; }
    public int RoleId { get; set; }

    public virtual ComicBook ComicBook { get; set; } = null!;
    public virtual Artist Artist { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}