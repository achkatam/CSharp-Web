namespace TaskboardApplication.Web.ViewModels.Board;

using Task;

public class BoardViewModel
{
    private readonly IEnumerable<TaskViewModel> tasks;

    public BoardViewModel()
    {
        this.tasks = new HashSet<TaskViewModel>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public IEnumerable<TaskViewModel> Tasks { get; set; }
}