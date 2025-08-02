

using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<bool> UserRoleAdd(int userId, int roleId);
        Task<List<UserRolesGetByUserId_Res>> UserRoleGet_GetByUserId(int userId);
        Task<List<UserRolesGetPermissionsByUserId_Res>> UserRoleGet_GetPermissionsByUserId(int userId);
        Task<bool> UserRoleRemove(int userId, int roleId);
    }

// sp_UserRoles_Add
// sp_UserRoles_GetByUserId
// sp_UserRolesGetPermissionsByUserId
// sp_UserRoles_Remove



}