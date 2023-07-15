namespace MVCIntroDemo.Controllers;

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

using ViewModels.Product;
using static Seeding.ProductsData;
public class ProductController : Controller
{
    [ActionName("My-Products")]
    public IActionResult AllProducts(string? keyword)
    {
        if (keyword is not null)
        {
            var foundProducts = Products
                .Where(p => p.Name
                    .ToLower()
                    .Contains(keyword.ToLower()));

            return View(foundProducts);
        }

        return View(Products);
    }

    public IActionResult ById(string id)
    {
        ProductViewModel? product = Products.FirstOrDefault(p => p.ProductId.Id.ToString().Equals(id));

        if (product == null)
        {
            return this.RedirectToAction("My-Products");
        }

        return this.View(product);
    }

    public IActionResult AllAsJson()
    {
        //string jsonText = JsonConvert.SerializeObject(Products, Formatting.Indented);

        //return Json(jsonText);

        return Json(Products, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
    }

    public IActionResult AllAsTextFile()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var product in Products)
        {
            sb
                .AppendLine($"Product: {product.ProductId.Id}: ")
                .AppendLine($"{product.Name} - ${product.Price:f2}")
                .AppendLine($"-----------------------------");
        }

        Response.Headers.Add(HeaderNames.ContentDisposition,
            @"attachment;filename=products.txt");

        return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
    }
}