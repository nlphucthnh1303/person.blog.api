

using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<bool> UserRoleAdd(int userId, int roleId);
        Task<List<RoleGet_Req>> UserRoleGet_ReqByUserId(int userId);
        Task<List<PermissionGet_Req>> UserRoleGet_ReqPermissionsByUserId(int userId); // Lấy tất cả quyền của user
        Task<bool> UserRoleRemove(int userId, int roleId);
    }
}