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

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<ComicBook>()
        //     .HasOne(cb => cb.Series)
        //     .WithMany(cb => cb.ComicBooks)
        //     .HasForeignKey(cb => cb.SeriesId)
        //     .IsRequired();
        
    }
}