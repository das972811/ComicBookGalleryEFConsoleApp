namespace ComicBook.Models;

public class ComicBook
{
    // Id, ID, ComicBookId, ComicBookID
    public int Id { get; set; }
    public string SeriesTitle { get; set; } = null!;
    public int IssueNumber { get; set; }
    public string Description { get; set; } = null!;
    public DateTime PublishedOn { get; set; }
}