// Repositories/Implementations/CommentRepository.cs


using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Comments;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories.Implementations
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<int> CommentCreate(CommentCreate_Req comment)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Comments_Create",
                    comment,
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

        public async Task<List<CommentGet_Req>> CommentGetByPostId(int postId, int pageNumber, int pageSize)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_PostId = postId,
                    p_Offset = (pageNumber - 1) * pageSize,
                    p_Limit = pageSize
                };
                return (await connection.QueryAsync<CommentGet_Req>(
                    "sp_Comments_GetByPostId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<CommentGet_Req?> CommentGetById(int commentId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_CommentId = commentId };
                return await connection.QueryFirstOrDefaultAsync<CommentGet_Req>(
                    "SELECT * FROM Comments WHERE CommentId = @p_CommentId", // Hoặc SP: sp_Comments_GetById
                    parameters
                );
            }
        }

        public async Task<bool> CommentUpdate(int commentId, CommentUpdate_Req comment)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_CommentId", commentId);
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