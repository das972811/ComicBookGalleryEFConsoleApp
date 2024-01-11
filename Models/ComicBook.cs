namespace ComicBookGallery.Models;

public class ComicBook
{
    // Id, ID, ComicBookId, ComicBookID
    public int Id { get; set; }
    public int SeriesId { get; set; }
    public Series Series { get; set; } = null!;
    public int IssueNumber { get; set; }
    public string Description { get; set; } = null!;
    public DateTime PublishedOn { get; set; }

    public decimal? AverageRating { get; set; }
}