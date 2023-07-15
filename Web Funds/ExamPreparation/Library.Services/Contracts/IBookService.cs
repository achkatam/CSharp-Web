namespace Library.Services.Contracts;

using ViewModels.Book;

public interface IBookService
{
    Task<IEnumerable<AllBookViewModel>> GetAllAsync();

    Task<IEnumerable<MineBookViewModel>> GetMyBookAsync(string userId);
    
    Task<BookViewModel?> GetBookByIdAsync(int id);
    Task<EditBookViewModel?> GetBookByIdForEditAsync(int id);

    Task AddToCollectionBookAsync(BookViewModel model, string userId);
    Task RemoveBookFromCollectionAsync(int bookId, string userId);
     
    Task<AddBookViewModel> GetNewBookAsync();

    Task AddNewBook(AddBookViewModel model);

    Task EditBookAsync(EditBookViewModel model, int id);
}