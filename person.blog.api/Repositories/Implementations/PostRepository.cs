// Repositories/Implementations/PostRepository.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Repositories.Interfaces;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Repositories.Implementations
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public PostRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<int> PostCreate(PostCreate post)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Posts_Create",
                    post,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> PostDelete(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Posts_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<PostGet?> PostGetById(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                return await connection.QueryFirstOrDefaultAsync<PostGet>(
                    "sp_Posts_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<PostGet?> PostGetBySlug(string slug)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Slug = slug };
                return await connection.QueryFirstOrDefaultAsync<PostGet>(
                    "sp_Posts_GetBySlug",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<List<PostListItem>> PostGetPublishedList(int pageNumber, int pageSize)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_Offset = (pageNumber - 1) * pageSize,
                    p_Limit = pageSize
                };
                return (await connection.QueryAsync<PostListItem>(
                    "sp_Posts_GetPublishedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<bool> PostIncrementViewCount(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Posts_IncrementViewCount",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<bool> PostUpdate(int postId, PostUpdate post)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_PostId", postId);
                parameters.Add("p_Title", post.Title);
                parameters.Add("p_Content", post.Content);
                parameters.Add("p_Slug", post.Slug);
                parameters.Add("p_CategoryId", post.CategoryId);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Posts_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<bool> PostUpdateStatus(int postId, string status)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_PostId = postId,
                    p_Status = status
                };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Posts_UpdateStatus",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<int> PostGetTotalPublishedPostCount()
        {
            using (var connection = GetConnection())
            {
                // Giả định bạn có SP này hoặc câu lệnh SELECT trực tiếp
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "SELECT COUNT(PostId) FROM Posts WHERE Status = 'Published' AND IsDeleted = FALSE"
                    // Hoặc "sp_Posts_GetTotalPublishedCount", commandType: CommandType.StoredProcedure
                );
            }
        }

       
    }
}