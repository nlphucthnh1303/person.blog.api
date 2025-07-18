// Repositories/Implementations/PermissionRepository.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Repositories.Interfaces;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Permissions;

namespace PersonBlogApi.Repositories.Implementations
{
    public class PermissionRepository : BaseRepository, IPermissionRepository
    {
        public PermissionRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<int> PermissionCreate(PermissionCreate permission)
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

        public async Task<List<PermissionGet>> PermissionGetAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<PermissionGet>(
                    "sp_Permissions_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<PermissionGet?> PermissionGetById(int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_PermissionId = permissionId };
                return await connection.QueryFirstOrDefaultAsync<PermissionGet>(
                    "sp_Permissions_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

            }
        }

        public async Task<PermissionGet?> PermissionGetByName(string name)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Name = name };
                return await connection.QueryFirstOrDefaultAsync<PermissionGet>(
                    "sp_Permissions_GetByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> PermissionUpdate(int permissionId, PermissionUpdate permission)
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