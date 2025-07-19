

using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<int> PostCreate_Req(PostCreate_Req post);
        Task<bool> PostDelete(int postId); 
        Task<PostGet_Req?> PostGet_ReqById(int postId);
        Task<PostGet_Req?> PostGet_ReqBySlug(string slug);
        Task<List<PostListItem_Req>> PostGet_ReqPublishedList(int pageNumber, int pageSize);
        Task<bool> PostIncrementViewCount(int postId);
        Task<bool> PostUpdate_Req(int postId, PostUpdate_Req post);
        Task<bool> PostUpdate_ReqStatus(int postId, string status);
        Task<int> PostGet_ReqTotalPublishedPostCount(); 
    }
}