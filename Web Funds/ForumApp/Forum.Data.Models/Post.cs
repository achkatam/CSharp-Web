namespace Forum.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Common.Validations.PostValidation;

public class Post
{
    public Post()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(CONTENT_MAX_LENGTH, MinimumLength = CONTENT_MIN_LENGTH)]
    public string Content { get; set; } = null!;
}