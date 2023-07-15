namespace Library.Services;

using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using ViewModels.Book;
using ViewModels.Category;

public class BookService : IBookService
{
    private readonly LibraryDbContext dbContext;

    public BookService(LibraryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
    {
        var books = await this.dbContext
            .Books
            .Select(b => new AllBookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Rating = b.Rating,
                Category = b.Category.Name
            })
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<MineBookViewModel>> GetMyBookAsync(string userId)
    {
        var books = await this.dbContext
            .UsersBooks.Where(ub => ub.CollectorId == userId)
            .Select(b => new MineBookViewModel()
            {
                Id = b.BookId,
                Title = b.Book.Title,
                Author = b.Book.Author,
                Description = b.Book.Description,
                ImageUrl = b.Book.ImageUrl,
                Category = b.Book.Category.Name,
            })
            .ToListAsync();

        return books;
    }

    public async Task<BookViewModel?> GetBookByIdAsync(int id)
    {
        var book = await this.dbContext
            .Books
            .Where(b => b.Id == id)
            .Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                CategoryId = b.CategoryId,
                Rating = b.Rating
            })
            .FirstOrDefaultAsync();

        return book;
    }


    public async Task AddToCollectionBookAsync(BookViewModel model, string userId)
    {
        bool alreadyAdded = await this.dbContext
            .UsersBooks
            .AnyAsync(ub => ub.BookId == model.Id && ub.CollectorId == userId);

        if (!alreadyAdded)
        {
            var userBook = new IdentityUserBook()
            {
                BookId = model.Id,
                CollectorId = userId
            };

            await this.dbContext.UsersBooks.AddAsync(userBook);

            await this.dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
    {
        var bookToRemove = await this.dbContext
            .UsersBooks
            .FirstOrDefaultAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);

        if (bookToRemove != null)
        {
            this.dbContext.UsersBooks.Remove(bookToRemove);

            await this.dbContext.SaveChangesAsync();
        }
    }

    public async Task<AddBookViewModel> GetNewBookAsync()
    {
        var categories = await this.dbContext.Categories
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
        var book = new Book
        {
            Title = model.Title,
            Author = model.Author,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            CategoryId = model.CategoryId,
            Rating = model.Rating
        };

        await this.dbContext.Books.AddAsync(book);
        await this.dbContext.SaveChangesAsync();

    }

    public async Task<EditBookViewModel?> GetBookByIdForEditAsync(int id)
    {
        var categories = await this.dbContext
            .Categories
            .Select(c => new CategoryViewModel()
        {
            Id = c.Id,
            Name = c.Name
        })
            .ToListAsync();

        var book = await this.dbContext
            .Books
            .Where(b => b.Id == id)
            .Select(b => new EditBookViewModel()
            {
                Description = b.Description,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating
            })
            .FirstOrDefaultAsync();

        return book;
    }
    public async Task EditBookAsync(EditBookViewModel model, int id)
    {
        var book = await this.dbContext
            .Books
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book != null)
        {
            book.Description = model.Description;
            book.ImageUrl = model.ImageUrl;
            book.Rating = model.Rating;

            await this.dbContext.SaveChangesAsync();
        }
    }
}