namespace Forum.Services.Interfaces;

using ViewModels.ViewModels;

public interface IPostService
{
    Task<IEnumerable<PostListViewModel>> GetAllAsync();

    Task AddPostAsync(PostFormModel model);

    Task<PostFormModel> GetPostForEditOrDeleteByIdAsync(string id);

    Task EditByIdAsync(string id, PostFormModel model);

    Task DeleteByIdAsync(string id);
}