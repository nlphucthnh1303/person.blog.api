

using PersonBlogApi.Models.Comments;

namespace PersonBlogApi.Services.Interfaces
{
    public interface ICommentService
    {
        Task<int> CommentCreate(CommentCreate_Req comment);
        Task<bool> CommentDelete(int commentId);
        Task<List<CommentGetByPostId_Res>> CommentGetByPostId(int postId);
        Task<bool> CommentUpdate(CommentUpdate_Req comment);
    }
    

}