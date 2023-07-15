namespace TaskboardApplication.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

using static Common.TaskValidations;

public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH)]
    public string Description { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
 
    public int BoardId { get; set; }

    public virtual Board? Board { get; set; }

    [Required] 
    public string OwnerId { get; set; } = null!;

    public virtual IdentityUser Owner { get; set; } = null!;
}