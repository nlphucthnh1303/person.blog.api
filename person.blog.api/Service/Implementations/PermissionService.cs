// Services/Implementations/PermissionService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Services.Interfaces;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Services.Implementations
{
    public class PermissionService : BaseService, IPermissionService
    {
        public PermissionService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> PermissionCreate(PermissionCreate_Req permission)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Name", permission.Name);
                parameters.Add("p_Description", permission.Description);

                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Permissions_Create",
                    permission,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> PermissionDelete(int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PermissionId = permissionId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Permissions_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<PermissionsGetAll_Res>> PermissionGetAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<PermissionsGetAll_Res>(
                    "sp_Permissions_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<PermissionsGetById_Res?> PermissionGetById(int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PermissionId = permissionId };
                return await connection.QueryFirstOrDefaultAsync<PermissionsGetById_Res>(
                    "sp_Permissions_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

            }
        }

        public async Task<PermissionsGetByName_Res?> PermissionGetByName(string name)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Name = name };
                return await connection.QueryFirstOrDefaultAsync<PermissionsGetByName_Res>(
                    "sp_Permissions_GetByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> PermissionUpdate(PermissionUpdate_Req permission)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_PermissionId", permission.PermissionId);
                parameters.Add("p_Name", permission.Name);
                parameters.Add("p_Description", permission.Description);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Permissions_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}