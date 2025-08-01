using PersonBlogApi.Models.Permissions;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IRolePermissionService
    {
        Task<bool> RolePermissionAdd(int roleId, int permissionId);
        Task<List<PermissionGet_Req>> RolePermissionGet_ReqByRoleId(int roleId);
        Task<bool> RolePermissionRemove(int roleId, int permissionId);
    }
}