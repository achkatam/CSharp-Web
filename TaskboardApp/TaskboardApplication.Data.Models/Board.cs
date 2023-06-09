namespace TaskboardApplication.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.BoardValidations;

public class Board
{
    public Board()
    {
        this.Tasks = new HashSet<Task>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(BOARD_NAME_MAX_LENGTH, MinimumLength = BOARD_NAME_MIN_LENGTH)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } 
}