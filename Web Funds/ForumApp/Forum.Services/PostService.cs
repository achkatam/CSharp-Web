namespace Forum.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Data.Models;
using Interfaces;
using ViewModels.ViewModels;

public class PostService : IPostService
{
    private readonly ForumDbContext dbContext;

    public PostService(ForumDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<PostListViewModel>> GetAllAsync()
    {
        IEnumerable<PostListViewModel> allPosts = await dbContext.Posts
            .Select(post => new PostListViewModel
            {
                Id = post.Id.ToString(),
                Title = post.Title,
                Content = post.Content
            })
            .ToArrayAsync();

        return allPosts;
    }

    public async Task AddPostAsync(PostFormModel model)
    {
        Post newPost = new Post
        {
            Title = model.Title,
            Content = model.Content
        };

        await this.dbContext.Posts.AddAsync(newPost);
        await this.dbContext.SaveChangesAsync();
    }

    public async Task<PostFormModel> GetPostForEditOrDeleteByIdAsync(string id)
    {
        Post postToEdit = await this.dbContext
            .Posts
            .FirstAsync(p => p.Id.ToString() == id);

        return new PostFormModel()
        {
            Title = postToEdit.Title,
            Content = postToEdit.Content
        };
    }

    public async Task EditByIdAsync(string id, PostFormModel model)
    {
        Post postToEdit = await this.dbContext
            .Posts
            .FirstAsync(p => p.Id.ToString() == id);

        postToEdit.Title = model.Title;
        postToEdit.Content = model.Content;

        await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        Post postToDelete = await this.dbContext
            .Posts
            .FirstAsync(p => p.Id.ToString() == id);

        this.dbContext.Posts.Remove(postToDelete);

        await this.dbContext.SaveChangesAsync();
    }
}