namespace Forum.Controllers;

using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.ViewModels;

public class PostController : Controller
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<PostListViewModel> allPosts =
            await this.postService.GetAllAsync();

        return View(allPosts);
    }

    public IActionResult Add()
    {
        return View(nameof(Add));
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this.postService.AddPostAsync(model);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while adding the post.");

            return View(model);
        }

        return RedirectToAction(nameof(GetAll), nameof(Post));
    }

    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            PostFormModel postModel =
                await this.postService.GetPostForEditOrDeleteByIdAsync(id);

            return View(postModel);
        }
        catch (Exception)
        {
            return RedirectToAction(nameof(GetAll), nameof(Post));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, PostFormModel postModel)
    {
        if (!ModelState.IsValid)
        {
            return this.View(postModel);
        }

        try
        {
            await this.postService.EditByIdAsync(id, postModel);

        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

            return View(postModel);
        }

        return RedirectToAction("GetAll", "Post");
    }
     

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await this.postService.DeleteByIdAsync(id);
        }
        catch (Exception)
        {
        }

        return RedirectToAction(nameof(GetAll), nameof(Post));

    }
}