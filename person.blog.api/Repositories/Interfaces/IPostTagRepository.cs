using PersonBlogApi.Models.PostTags;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IPostTagRepository
    {
        Task<bool> PostTagAdd(int postId, int tagId);
        Task<List<PostTagGet_Req_Req>> PostTagGet_Req_ReqByPostId(int postId); // Trả về danh sách tags liên quan
        Task<bool> PostTagRemove(int postId, int tagId);
    }
}