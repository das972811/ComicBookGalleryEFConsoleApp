using ComicBookGallery;
using ComicBookGallery.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new Context())
{
    context.ComicBooks.Add(new ComicBook {
        Series = new() { Title = "The Amazing Spider Man" },
        IssueNumber = 1,
        Description = "Awesome comic book",
        PublishedOn = DateTime.Now
    });

    context.SaveChanges();

    var comicBooks = context.ComicBooks
        .Include(cb => cb.Series)
        .ToList();
    foreach (var comicBook in comicBooks)
    {
        Console.WriteLine(comicBook.Series.Title);
    }

    Console.ReadLine();
}