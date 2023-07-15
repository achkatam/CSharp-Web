namespace MVCIntroDemo.ViewModels.Product;

public class ProductViewModel
{
    public ProductId ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}