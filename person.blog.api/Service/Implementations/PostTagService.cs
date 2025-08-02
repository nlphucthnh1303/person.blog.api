
using Dapper;
using ersonBlogApi.Services;
using PersonBlogApi.Models.PostTags;
using PersonBlogApi.Services.Interfaces;


namespace PersonBlogApi.Services.Implementations
{
    public class PostTagService : BaseService, IPostTagService
    {
        public PostTagService(IConfiguration configuration) : base(configuration) { }

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

        public async Task<List<PostTagGet_Req_Req>> PostTagGet_Req_ReqByPostId(int postId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PostId = postId };
                return (await connection.QueryAsync<PostTagGet_Req_Req>(
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