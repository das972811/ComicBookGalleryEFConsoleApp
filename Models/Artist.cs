namespace ComicBookGallery.Models;

public class Artist
{
    public Artist()
    {
        ComicBooks = new List<ComicBook>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ComicBook> ComicBooks { get; set; } = null!;
}