namespace Library.Data.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.CategoryValidations;

public class Category
{
    public Category()
    {
        this.Books = new HashSet<Book>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(CATEGORY_NAME_MAX_LENGTH, MinimumLength = CATEGORY_NAME_MIN_LENGTH)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; }
}