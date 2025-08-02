// Services/Implementations/PostService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Services.Interfaces;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Services.Implementations
{
    public class PostService : BaseService, IPostService
    {
        public PostService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> PostCreate(PostCreate_Req post)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Title", post.Title);
                parameters.Add("p_Content", post.Content);
                parameters.Add("p_Slug", post.Slug);
                parameters.Add("p_Summary", post.Summary);
                parameters.Add("p_ThumbnailUrl", post.ThumbnailUrl);
                parameters.Add("p_AuthorId", post.AuthorId);
                parameters.Add("p_CategoryId", post.CategoryId);
                parameters.Add("p_Status", post.Status);  
                return await connection.ExecuteAsync(
                    "sp_Posts_Create",
                    parameters,
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

        public async Task<PostGetById_Res?> PostGetById(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                return await connection.QueryFirstOrDefaultAsync<PostGetById_Res>(
                    "sp_Posts_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<PostGetBySlug_Res?> PostGetBySlug(string slug)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Slug = slug };
                return await connection.QueryFirstOrDefaultAsync<PostGetBySlug_Res>(
                    "sp_Posts_GetBySlug",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<List<PostGetPublishedList_Res>> PostGetPublishedList(int pageNumber, int pageSize)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_Offset = (pageNumber - 1) * pageSize,
                    p_Limit = pageSize
                };
                return (await connection.QueryAsync<PostGetPublishedList_Res>(
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

        public async Task<bool> PostUpdate(PostUpdate_Req post)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_PostId", post.PostId);
                parameters.Add("p_Title", post.Title);
                parameters.Add("p_Content", post.Content);
                parameters.Add("p_Slug", post.Slug);
                parameters.Add("p_Summary", post.Summary);
                parameters.Add("p_ThumbnailUrl", post.ThumbnailUrl);
                parameters.Add("p_AuthorId", post.AuthorId);
                parameters.Add("p_CategoryId", post.CategoryId);
                parameters.Add("p_Status", post.Status); 
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

       
    }
}