namespace TextSplitter.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextSplitter.Models;
using ViewModels;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(TextViewModel model)
    => View(model);

    public IActionResult Split(TextViewModel model)
    {
        var splitTextArray = model
            .Text
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        model.SplitText = string.Join(Environment.NewLine, splitTextArray);

        return RedirectToAction("Index", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}