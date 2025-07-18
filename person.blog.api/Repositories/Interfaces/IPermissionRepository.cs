

using PersonBlogApi.Models.Permissions;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        Task<int> PermissionCreate(PermissionCreate permission);
        Task<bool> PermissionDelete(int permissionId);
        Task<List<PermissionGet>> PermissionGetAll();
        Task<PermissionGet?> PermissionGetById(int permissionId);
        Task<PermissionGet?> PermissionGetByName(string name);
        Task<bool> PermissionUpdate(int permissionId, PermissionUpdate permission);
    }
}