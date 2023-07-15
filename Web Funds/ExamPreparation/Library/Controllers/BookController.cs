namespace Library.Server.Controllers;
 
using Services.Contracts; 

using Microsoft.AspNetCore.Mvc;

using ViewModels.ViewModels.Book;

public class BookController : BaseController
{
    private readonly IBookService bookService;

    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = await this.bookService.GetAllAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        var model = await this.bookService.GetMyBooksAsync(GetUserID());

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCollection(int id)
    {
        var book = await this.bookService.GetBookById(id);

        if (book == null)
        {
            return RedirectToAction(nameof(All));
        }

        var userId = GetUserID();

        await bookService.AddToCollectionAsync(userId, book);

        return RedirectToAction(nameof(All));
    }


    [HttpPost]
    public async Task<IActionResult> RemoveFromCollection(int id)
    {
        var book = await this.bookService.GetBookById(id);

        if (book != null)
        {
            var userId = GetUserID();

            await bookService.RemoveFromCollectionAsync(userId, book);

        }

        return RedirectToAction(nameof(Mine));
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        AddBookViewModel model = await this.bookService.GetNewAddBookModelASync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddBookViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        await this.bookService.AddNewBook(model);

        return RedirectToAction(nameof(All));
    }
}