// Repositories/Implementations/CommentLikeService.cs
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories.Implementations
{
    public class CommentLikeService : BaseService, ICommentLikeService
    {
        public CommentLikeService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> CommentLikeAdd(int commentId, int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_CommentId = commentId, P_UserId = userId };
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_CommentLikes_Add",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> CommentLikeCheckUserLiked(int commentId, int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_CommentId = commentId, P_UserId = userId };
                // Giả định SP trả về 1 nếu đã like, 0 nếu chưa
                return await connection.QuerySingleOrDefaultAsync<bool>(
                    "sp_CommentLikes_CheckUserLiked",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<int> CommentLikeCountByCommentId(int commentId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_CommentId = commentId };
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_CommentLikes_CountByCommentId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> CommentLikeRemove(int commentId, int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_CommentId = commentId, P_UserId = userId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_CommentLikes_Remove",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}