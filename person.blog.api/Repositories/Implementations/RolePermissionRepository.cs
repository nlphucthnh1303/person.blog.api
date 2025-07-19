// Repositories/Implementations/RolePermissionRepository.cs
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Repositories.Interfaces;


namespace PersonBlogApi.Repositories.Implementations
{
    public class RolePermissionRepository : BaseRepository, IRolePermissionRepository
    {
        public RolePermissionRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> RolePermissionAdd(int roleId, int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_RoleId = roleId, P_PermissionId = permissionId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_RolePermissions_Add",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<PermissionGet_Req>> RolePermissionGet_ReqByRoleId(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                return (await connection.QueryAsync<PermissionGet_Req>(
                    "sp_RolePermissions_GetByRoleId", // Giả định SP này join và trả về thông tin Permission
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<bool> RolePermissionRemove(int roleId, int permissionId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_RoleId = roleId, P_PermissionId = permissionId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_RolePermissions_Remove",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }




    }
}