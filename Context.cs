using Microsoft.EntityFrameworkCore;
using ComicBookGallery.Models;
using System.Runtime.InteropServices;

namespace ComicBookGallery;

public class Context : DbContext
{
    public DbSet<ComicBook> ComicBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=(localdb)\\mylocaldb;Database=ComicBookGallery;Trusted_Connection=True;";

        optionsBuilder.UseSqlServer(connectionString);
    }
}