// Services/Implementations/CommentService.cs


using Dapper;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Comments;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Services.Implementations
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> CommentCreate(CommentCreate_Req comment)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_PostId",comment.PostId);
                parameters.Add("p_UserId", comment.UserId);
                parameters.Add("p_Content", comment.Content);
                parameters.Add("p_ParentCommentId", comment.ParentCommentId);
                return await connection.ExecuteAsync(
                    "sp_Comments_Create",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> CommentDelete(int commentId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_CommentId = commentId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Comments_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<CommentGetByPostId_Res>> CommentGetByPostId(int postId)
        {
            using (var connection = GetConnection())
            {
                 var parameters = new { p_PostId = postId };
                return (await connection.QueryAsync<CommentGetByPostId_Res>(
                    "sp_Comments_GetByPostId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<bool> CommentUpdate(CommentUpdate_Req comment)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_CommentId", comment.CommentId);
                parameters.Add("p_Content", comment.Content);
                // Thêm các tham số khác nếu SP của bạn có

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Comments_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}