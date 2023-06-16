namespace Library.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using Category;
using static Common.Validations.BookValidations;

public class EditBookViewModel
{ 

    [Required]
    [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH)]
    public string Description { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [Range(RATING_MIN_VALUE, RATING_MAX_VALUE)]
    public decimal Rating { get; set; }
}