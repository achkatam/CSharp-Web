namespace Library.Data.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.Validations.BookValidations;

public class Book
{
    public Book()
    {
        this.UsersBooks = new HashSet<IdentityUserBook>();
    }

    [Key] public int Id { get; set; }

    [Required]
    [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(AUTHOR_MAX_LENGTH, MinimumLength = AUTHOR_MIN_LENGTH)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH)]
    public string Description { get; set; } = null!;

    [Required] public string ImageUrl { get; set; } = null!;

    [Required]
    [Range((double)RATING_MIN_VALUE, (double)RATING_MAX_VALUE)]
    public decimal Rating { get; set; }

    [ForeignKey(nameof(Category))] public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<IdentityUserBook> UsersBooks { get; set; }
}