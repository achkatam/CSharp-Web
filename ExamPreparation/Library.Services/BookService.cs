namespace Library.Services;

using Microsoft.EntityFrameworkCore;

using Contracts;
using Data.Data.Models;
using Library.Data.Data;
using ViewModels.ViewModels.Book;
using ViewModels.ViewModels.Category;

public class BookService : IBookService
{
    private readonly LibraryDbContext dbContext;

    public BookService(LibraryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
    {
        var books = await dbContext.Books
            .Select(b => new AllBookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Category = b.Category.Name
            })
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId)
    {
        var myBooks = await dbContext
            .UsersBooks
            .Where(ub => ub.CollectorId == userId)
            .Select(b => new MineBookViewModel()
            {
                Id = b.Book.Id,
                Title = b.Book.Title,
                Author = b.Book.Author,
                ImageUrl = b.Book.ImageUrl,
                Description = b.Book.Description,
                Category = b.Book.Category.Name
            })
            .ToListAsync();

        return myBooks;
    }

    public async Task<BookViewModel?> GetBookById(int id)
    {
        var book = await dbContext
            .Books
            .Where(b => b.Id == id)
            .Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Description = b.Description,
                CategoryId = b.CategoryId,
                Rating = b.Rating
            })
            .FirstOrDefaultAsync();

        return book;
    }
    public async Task AddToCollectionAsync(string userId, BookViewModel book)
    {
        bool alreadyAdded = await dbContext
            .UsersBooks
            .AnyAsync(ub => ub.CollectorId == userId);

        if (!alreadyAdded)
        {
            var userBook = new IdentityUserBook
            {
                CollectorId = userId,
                BookId = book.Id
            };

            await dbContext.UsersBooks.AddAsync(userBook);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveFromCollectionAsync(string userId, BookViewModel book)
    {
        var bookToRemove = await dbContext
                .UsersBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

        if (bookToRemove != null)
        {

            dbContext.UsersBooks.Remove(bookToRemove);

            await dbContext.SaveChangesAsync();
        }

    }

    public async Task<AddBookViewModel> GetNewAddBookModelASync()
    {
        var categories = await dbContext.Categories
             .Select(c => new CategoryViewModel()
             {
                 Id = c.Id,
                 Name = c.Name
             })
             .ToListAsync();

        var model = new AddBookViewModel()
        {
            Categories = categories
        };

        return model;
    }

    public async Task AddNewBook(AddBookViewModel model)
    {
        Book book = new Book
        {
            Title = model.Title,
            Author = model.Author,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Rating = model.Rating,
            CategoryId = model.CategoryId
        };

        await dbContext.Books.AddAsync(book);
        await dbContext.SaveChangesAsync();
    }
}