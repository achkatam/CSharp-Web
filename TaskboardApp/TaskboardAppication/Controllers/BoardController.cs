namespace TaskboardApplication.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;
using Microsoft.AspNetCore.Authorization;
using TaskboardAppication.Services.Interfaces;
using Web.ViewModels.Board;
using Web.ViewModels.Task;

[Authorize]
public class BoardController : Controller
{
    private readonly IBoardService boardService;

    public BoardController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<BoardViewModel> allBoards =
            await this.boardService.AllAsync();

        return this.View(allBoards);
    }
}