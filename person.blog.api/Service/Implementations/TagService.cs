// Services/Implementations/TagService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Services.Interfaces;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Tags;

namespace PersonBlogApi.Services.Implementations
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> TagCreate(TagCreate_Req tag)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Name", tag.Name);
                parameters.Add("p_Slug", tag.Slug);
                parameters.Add("p_Description", tag.Description);  
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Tags_Create",
                    parameters,
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

        public async Task<List<TagGetAll_Res>> TagGetAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<TagGetAll_Res>(
                    "sp_Tags_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<TagGetById_Res?> TagGetById(int tagId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_TagId = tagId };
                return await connection.QueryFirstOrDefaultAsync<TagGetById_Res>(
                    "sp_Tags_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<TagGetBySlug_Res?> TagGetBySlug(string slug)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Slug = slug };
                return await connection.QueryFirstOrDefaultAsync<TagGetBySlug_Res>(
                    "sp_Tags_GetBySlug",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> TagUpdate(int tagId, TagUpdate_Req tag)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_TagId", tagId);
                parameters.Add("p_Name", tag.Name);
                parameters.Add("p_Slug", tag.Slug);
                parameters.Add("p_Description", tag.Description);
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