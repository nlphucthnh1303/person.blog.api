

using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<bool> UserRoleAdd(int userId, int roleId);
        Task<List<RoleGet>> UserRoleGetByUserId(int userId);
        Task<List<PermissionGet>> UserRoleGetPermissionsByUserId(int userId); // Lấy tất cả quyền của user
        Task<bool> UserRoleRemove(int userId, int roleId);
    }
}