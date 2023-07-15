namespace TaskboardAppication.Services;

using Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskboardApplication.Data;
using TaskboardApplication.Web.ViewModels.Board;
using TaskboardApplication.Web.ViewModels.Task;

public class BoardService : IBoardService
{
    private readonly TaskBoardAppDbContext dbContext;

    public BoardService(TaskBoardAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<BoardViewModel>> AllAsync()
    {
        IEnumerable<BoardViewModel> allBoards = await this.dbContext
            .Boards.Select(b => new BoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks.Select(t => new TaskViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName
                })
                    .ToArray()
            })
            .ToArrayAsync();

        return allBoards;
    }

    public async Task<IEnumerable<TaskBoardModel>> AllForSelectAsync()
    {
        IEnumerable<TaskBoardModel> allBoards = await this.dbContext
            .Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToArrayAsync();

        return allBoards;
    }

    public async Task<bool> ExistByIdAsync(int id)
    {
        bool result = await this.dbContext
            .Boards
            .AnyAsync(b => b.Id == id);

        return result;
    }
}