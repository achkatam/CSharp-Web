namespace MVCIntroDemo.Seeding;
 
using ViewModels.Product;

public static class ProductsData
{
    public static IEnumerable<ProductViewModel> Products =
        new List<ProductViewModel>()
        {
            new ProductViewModel()
            {
                ProductId = new ProductId(),
                Name = "Cheese",
                Price = 7.25m
            },
            new ProductViewModel()
            {
                ProductId =  new ProductId(),
                Name = "Ham",
                Price = 21m
            },
            new ProductViewModel()
            {
                ProductId = new ProductId(),
                Name = "Salami",
                Price = 14.65m
            }
        };
}