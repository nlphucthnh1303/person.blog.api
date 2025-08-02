

namespace PersonBlogApi.Services.Interfaces
{
    public interface ICommentLikeService
    {
        Task<int> CommentLikeAdd(int commentId, int userId); // Trả về ID của like mới
        Task<bool> CommentLikeCheckUserLiked(int commentId, int userId);
        Task<int> CommentLikeCountByCommentId(int commentId);
        Task<bool> CommentLikeRemove(int commentId, int userId);
    }
}