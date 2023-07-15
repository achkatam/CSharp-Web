namespace TaskboardApplication.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskboardAppication.Services.Interfaces;
using Web.ViewModels.Task;

[Authorize]
public class TaskController : Controller
{
    private readonly IBoardService boardService;

    public TaskController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        TaskFormModel taskModel = new TaskFormModel()
        { 
            Boards = await this.boardService.AllForSelectAsync()
        };

        return this.View(taskModel); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel taskModel)
    {
        if (!this.ModelState.IsValid)
        {
            taskModel.Boards = await this.boardService.AllForSelectAsync();

            return this.View(taskModel);
        }
        
        bool boardExists = await this.boardService.ExistByIdAsync(taskModel.BoardId);

        if (!boardExists)
        {
            taskModel.Boards = await this.boardService.AllForSelectAsync();

            ModelState.AddModelError(nameof(taskModel.BoardId), "Selected board does not exist!");

            return this.View(taskModel);
        }

        return this.RedirectToAction("All", "Board");
    }

}