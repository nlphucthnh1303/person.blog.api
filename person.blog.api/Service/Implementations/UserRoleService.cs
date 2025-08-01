// Repositories/Implementations/UserRoleService.cs
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories.Implementations
{
    public class UserRoleService : BaseService, IUserRoleService
    {
        public UserRoleService(IConfiguration configuration) : base(configuration) { }

        public async Task<bool> UserRoleAdd(int userId, int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_UserId = userId, P_RoleId = roleId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserRoles_Add",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<RoleGet_Req>> UserRoleGet_ReqByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                return (await connection.QueryAsync<RoleGet_Req>(
                    "sp_UserRoles_GetByUserId", // Giả định SP này join và trả về thông tin Role
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<List<PermissionGet_Req>> UserRoleGet_ReqPermissionsByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                // Giả định SP này join UserRoles -> Roles -> RolePermissions -> Permissions
                return (await connection.QueryAsync<PermissionGet_Req>(
                    "sp_UserRoles_GetPermissionsByUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<bool> UserRoleRemove(int userId, int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { P_UserId = userId, P_RoleId = roleId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserRoles_Remove",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }




    }
}