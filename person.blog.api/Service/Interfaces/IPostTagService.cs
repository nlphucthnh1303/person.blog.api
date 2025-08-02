using PersonBlogApi.Models.PostTags;
using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IPostTagService
    {
        Task<bool> PostTagAdd(int postId, int tagId);
        Task<List<PostTagGetByPostId_Res>> PostTagGetByPostId(int postId); // Trả về danh sách tags liên quan
        Task<bool> PostTagRemove(int postId, int tagId);
    }
}