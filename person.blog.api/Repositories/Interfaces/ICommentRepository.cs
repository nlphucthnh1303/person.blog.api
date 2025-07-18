

using PersonBlogApi.Models.Comments;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> CommentCreate(CommentCreate comment);
        Task<bool> CommentDelete(int commentId);
        Task<List<CommentGet>> CommentGetByPostId(int postId, int pageNumber, int pageSize);
        Task<CommentGet?> CommentGetById(int commentId); 
        Task<bool> CommentUpdate(int commentId, CommentUpdate comment);
    }
}