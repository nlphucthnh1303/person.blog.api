// Repositories/Implementations/PermissionService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Repositories.Interfaces;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Permissions;

namespace PersonBlogApi.Repositories.Implementations
{
    public class PermissionService : BaseService, IPermissionService
    {
        public PermissionService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> PermissionCreate_Req(PermissionCreate_Req permission)
        {
            using (var connection = GetConnection())
            {
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

        public async Task<List<PermissionGet_Req>> PermissionGet_ReqAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<PermissionGet_Req>(
                    "sp_Permissions_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<PermissionGet_Req?> PermissionGet_ReqById(int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PermissionId = permissionId };
                return await connection.QueryFirstOrDefaultAsync<PermissionGet_Req>(
                    "sp_Permissions_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

            }
        }

        public async Task<PermissionGet_Req?> PermissionGet_ReqByName(string name)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Name = name };
                return await connection.QueryFirstOrDefaultAsync<PermissionGet_Req>(
                    "sp_Permissions_GetByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> PermissionUpdate_Req(int permissionId, PermissionUpdate_Req permission)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_PermissionId", permissionId);
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