

using PersonBlogApi.Models.Comments;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> CommentCreate(CommentCreate_Req comment);
        Task<bool> CommentDelete(int commentId);
        Task<List<CommentGet_Req>> CommentGetByPostId(int postId, int pageNumber, int pageSize);
        Task<CommentGet_Req?> CommentGetById(int commentId); 
        Task<bool> CommentUpdate(int commentId, CommentUpdate_Req comment);
    }
}