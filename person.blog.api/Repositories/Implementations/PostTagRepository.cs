
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.PostTags;
using PersonBlogApi.Repositories.Interfaces;


namespace PersonBlogApi.Repositories.Implementations
{
    public class PostTagRepository : BaseRepository, IPostTagRepository
    {
        public PostTagRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> PostTagAdd(int postId, int tagId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_PostId = postId, P_TagId = tagId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_PostTags_Add",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<PostTagGet>> PostTagGetByPostId(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                return (await connection.QueryAsync<PostTagGet>(
                    "sp_PostTags_GetByPostId", 
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<bool> PostTagRemove(int postId, int tagId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_PostId = postId, P_TagId = tagId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_PostTags_Remove",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}