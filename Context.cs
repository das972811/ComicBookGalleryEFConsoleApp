
using ComicBookGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBookGallery;

public class Context : DbContext
{
    public DbSet<ComicBook> ComicBooks { get; set; }
}