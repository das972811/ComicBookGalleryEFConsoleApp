namespace ComicBookGallery.Models;

public class ComicBook
{
    public ComicBook()
    {
        Artists = new List<ComicBookArtist>();
    }

    // Id, ID, ComicBookId, ComicBookID
    public int Id { get; set; }
    public int SeriesId { get; set; }
    public Series Series { get; set; } = null!;
    public int IssueNumber { get; set; }
    public string Description { get; set; } = null!;
    public DateTime PublishedOn { get; set; }
    public decimal? AverageRating { get; set; }
    public ICollection<ComicBookArtist> Artists { get; set; } = null!;

    public string DisplayText
    {
        get
        {
            return $"{Series?.Title} #{IssueNumber}";
        }
    }

    public void AddArtist(Artist artist, Role role)
    {
        Artists.Add(new ComicBookArtist() {
            Artist = artist,
            Role = role
        });
    }
}