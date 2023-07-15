namespace Forum.ViewModels.ViewModels;

using System.ComponentModel.DataAnnotations;

using static Common.Common.Validations.PostValidation;

public class PostFormModel
{
    [Required]
    [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(CONTENT_MAX_LENGTH, MinimumLength = CONTENT_MIN_LENGTH)]
    public string Content { get; set; } = null!;
}