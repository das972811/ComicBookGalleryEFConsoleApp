using ComicBookGallery;
using ComicBookGallery.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new Context())
{
    Series series1 = new() { Title = "The Amazing Spider Man" };
    Series series2 = new() { Title = "The Invincible Iron Man" };

    var artist1 = new Artist() { Name = "Stan Lee" };
    var artist2 = new Artist() { Name = "Steve Dikto" };
    var artist3 = new Artist() { Name = "Jack Kirby" };

    var comicBook1 = new ComicBook()
    {
        Series = series1,
        IssueNumber = 1,
        Description = "Peter get's bitten by a radioactive spider!",
        PublishedOn = DateTime.Today
    };

    comicBook1.Artists.Add(artist1);
    comicBook1.Artists.Add(artist2);

    var comicBook2 = new ComicBook()
    {
        Series = series2,
        IssueNumber = 2,
        Description = "Tony starts build his iron man suit",
        PublishedOn = DateTime.Today
    };

    comicBook2.Artists.Add(artist2);
    comicBook2.Artists.Add(artist3);

    context.ComicBooks.Add(comicBook1);
    context.ComicBooks.Add(comicBook2);

    context.SaveChanges();

    var comicBooks = context.ComicBooks
        .Include(cb => cb.Series)
        .Include(cb => cb.Artists)
        .ToList();
    
    foreach (var comicBook in comicBooks)
    {
        var artistNames = comicBook.Artists.Select(a => a.Name).ToList();
        var artistDisplayText = string.Join(", ", artistNames);
        Console.WriteLine(comicBook.DisplayText);
        Console.WriteLine(artistDisplayText);
    }

    Console.ReadLine();
}