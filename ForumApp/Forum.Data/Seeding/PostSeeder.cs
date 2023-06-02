namespace Forum.Data.Seeding;
 
using Models;

class PostSeeder
{
    internal Post[] GeneratePosts()
    {
        ICollection<Post> posts = new HashSet<Post>();

        Post currPost;

        currPost = new Post()
        {
            Title = "First Post",
            Content = "First Post Content"
        };

        posts.Add(currPost);

        currPost = new Post()
        {
            Title = "Second Post",
            Content = "Second Post Content"
        };

        posts.Add(currPost);


        currPost = new Post()
        {
            Title = "Third Post",
            Content = "Third Post Content"
        };

        posts.Add(currPost);

        return posts.ToArray();
    }
}