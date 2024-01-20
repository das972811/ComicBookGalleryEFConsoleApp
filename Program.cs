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

    var role1 = new Role() { Name = "Script" };
    var role2 = new Role() { Name = "Pencils" };


    var comicBook1 = new ComicBook()
    {
        Series = series1,
        IssueNumber = 1,
        Description = "Peter get's bitten by a radioactive spider!",
        PublishedOn = DateTime.Today
    };

    comicBook1.AddArtist(artist1, role1);
    comicBook1.AddArtist(artist2, role2);

    var comicBook2 = new ComicBook()
    {
        Series = series2,
        IssueNumber = 2,
        Description = "Tony starts build his iron man suit",
        PublishedOn = DateTime.Today
    };

    comicBook2.AddArtist(artist2, role1);
    comicBook2.AddArtist(artist3, role2);

    // context.ComicBooks.Add(comicBook1);
    // context.ComicBooks.Add(comicBook2);

    // context.SaveChanges();

    var comicBooks = context.ComicBooks
        .Include(cb => cb.Series)
        .Include(cb => cb.Artists)
        .ThenInclude(a => a.Artist)
        .Include(cb => cb.Artists)
        .ThenInclude(r => r.Role)
        .ToList();
    
    foreach (var comicBook in comicBooks)
    {
        var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}");
        var artistRolesDisplayText = string.Join(", ", artistRoleNames);

        Console.WriteLine(comicBook.DisplayText);
        Console.WriteLine(artistRolesDisplayText);
    }

    Console.ReadLine();
}