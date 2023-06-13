namespace Library.Data.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class IdentityUserBook
{
    [ForeignKey(nameof(IdentityUser))]
    public string CollectorId { get; set; } = null!;
    public virtual IdentityUser Collector { get; set; } = null!;


    [ForeignKey(nameof(Book))]
    public int BookId { get; set; }
    public virtual Book Book { get; set; } = null!;
}