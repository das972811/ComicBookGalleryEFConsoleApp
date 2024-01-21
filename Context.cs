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
        // optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Using the fluent Api
        base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<ComicBook>()
        //     .HasOne(cb => cb.Series)
        //     .WithMany(cb => cb.ComicBooks)
        //     .HasForeignKey(cb => cb.SeriesId)
        //     .IsRequired();
        // modelBuilder.Entity<ComicBookArtist>()
        //     .HasRequired(cba => cba.ComicBook)
        //     .WithMany(cb => cb.Artists)
        //     .HasForeignKey(cba => cba.ComicBookId)
        //     .WillCascadeOnDelete(false);

        modelBuilder.Entity<ComicBookArtist>()
            .HasOne(cba => cba.ComicBook)
            .WithMany(cba => cba.Artists)
            .HasForeignKey(cba => cba.ComicBookId)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<ComicBook>()
            .Property(cb => cb.AverageRating)
            .HasPrecision(5, 2);
    }
}