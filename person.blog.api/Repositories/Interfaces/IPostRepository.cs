

using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<int> PostCreate(PostCreate post);
        Task<bool> PostDelete(int postId); 
        Task<PostGet?> PostGetById(int postId);
        Task<PostGet?> PostGetBySlug(string slug);
        Task<List<PostListItem>> PostGetPublishedList(int pageNumber, int pageSize);
        Task<bool> PostIncrementViewCount(int postId);
        Task<bool> PostUpdate(int postId, PostUpdate post);
        Task<bool> PostUpdateStatus(int postId, string status);
        Task<int> PostGetTotalPublishedPostCount(); 
    }
}