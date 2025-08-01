// Repositories/Implementations/TagService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Repositories.Interfaces;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Tags;

namespace PersonBlogApi.Repositories.Implementations
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> TagCreate_Req(TagCreate_Req tag)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Tags_Create",
                    tag,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> TagDelete(int tagId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_TagId = tagId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Tags_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<TagGet_Req>> TagGet_ReqAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<TagGet_Req>(
                    "sp_Tags_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<TagGet_Req?> TagGet_ReqById(int tagId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_TagId = tagId };
                return await connection.QueryFirstOrDefaultAsync<TagGet_Req>(
                    "sp_Tags_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<TagGet_Req?> TagGet_ReqBySlug(string slug)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Slug = slug };
                return await connection.QueryFirstOrDefaultAsync<TagGet_Req>(
                    "sp_Tags_GetBySlug",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> TagUpdate_Req(int tagId, TagUpdate_Req tag)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_TagId", tagId);
                parameters.Add("p_Name", tag.Name);
                parameters.Add("p_Slug", tag.Slug);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Tags_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}