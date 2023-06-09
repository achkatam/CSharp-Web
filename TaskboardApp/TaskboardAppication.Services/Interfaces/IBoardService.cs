namespace TaskboardAppication.Services.Interfaces;

using TaskboardApplication.Web.ViewModels.Board;
using TaskboardApplication.Web.ViewModels.Task;

public interface IBoardService
{
    Task<IEnumerable<BoardViewModel>> AllAsync();

    Task<IEnumerable<TaskBoardModel>> AllForSelectAsync();

    Task<bool> ExistByIdAsync(int id);
}