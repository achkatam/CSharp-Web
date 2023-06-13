namespace Library.Services.Contracts;

using ViewModels.ViewModels.Book;

public interface IBookService
{
    Task<IEnumerable<AllBookViewModel>> GetAllAsync();

    Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId);

    Task<BookViewModel?> GetBookById(int id);

    Task AddToCollectionAsync(string userId, BookViewModel book);

    Task RemoveFromCollectionAsync(string userId, BookViewModel book);
    Task<AddBookViewModel> GetNewAddBookModelASync();
    Task AddNewBook(AddBookViewModel model);
}