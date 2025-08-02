// Services/Implementations/RolePermissionService.cs
using Dapper;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;
using PersonBlogApi.Services.Interfaces;


namespace PersonBlogApi.Services.Implementations
{
    public class RolePermissionService : BaseService, IRolePermissionService
    {
        public RolePermissionService(IConfiguration configuration) : base(configuration) { }

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

        public async Task<List<RolePermissionGetByRoleId_Res>> RolePermissionGetByRoleId(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                return (await connection.QueryAsync<RolePermissionGetByRoleId_Res>(
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