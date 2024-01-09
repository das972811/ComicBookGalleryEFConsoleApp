using ComicBookGallery;
using ComicBookGallery.Models;

using (var context = new Context())
{
    context.ComicBooks.Add(new ComicBook {
        SeriesTitle = "The Amazing Spider-Man",
        IssueNumber = 1,
        Description = "Awesome comic book",
        PublishedOn = DateTime.Now
    });

    context.SaveChanges();

    var comicBooks = context.ComicBooks.ToList();
    foreach (var comicBook in comicBooks)
    {
        Console.WriteLine(comicBook.SeriesTitle);
    }

    Console.ReadLine();
}