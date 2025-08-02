using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IRolePermissionService
    {
        Task<bool> RolePermissionAdd(int roleId, int permissionId);
        Task<List<RolePermissionGetByRoleId_Res>> RolePermissionGetByRoleId(int roleId);
        Task<bool> RolePermissionRemove(int roleId, int permissionId);
    }

}