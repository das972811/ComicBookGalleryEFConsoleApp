using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicBookGallery.Models;

[Table("Talent")]
public class Artist
{
    public Artist()
    {
        ComicBooks = new List<ComicBookArtist>();
    }
    public int Id { get; set; }
    [StringLength(100), Column("FullName")]
    public string Name { get; set; } = null!;
    public ICollection<ComicBookArtist> ComicBooks { get; set; } = null!;
}