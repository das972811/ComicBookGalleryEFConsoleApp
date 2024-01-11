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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComicBook>()
            .HasOne(cb => cb.Series)
            .WithMany(cb => cb.ComicBooks)
            .HasForeignKey(cb => cb.SeriesId)
            .IsRequired();
    }
}