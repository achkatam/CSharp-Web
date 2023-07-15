namespace TaskboardApplication.Web.ViewModels.Task;

using System.ComponentModel.DataAnnotations;
using static Common.TaskValidations;
using static Common.ErrorMessages;

public class TaskFormModel
{
    [Required]
    [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH,
        ErrorMessage = TITLE_MIN_LENGTH_S)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH,
        ErrorMessage = DESCRIPTION_MIN_LENGTH_S)]
    public string Description { get; set; } = null!;

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
}