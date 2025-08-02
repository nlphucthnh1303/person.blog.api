

using PersonBlogApi.Models.Permissions;
using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<int> PermissionCreate(PermissionCreate_Req permission);
        Task<bool> PermissionDelete(int permissionId);
        Task<List<PermissionsGetAll_Res>> PermissionGetAll();
        Task<PermissionsGetById_Res?> PermissionGetById(int permissionId);
        Task<PermissionsGetByName_Res?> PermissionGetByName(string name);
        Task<bool> PermissionUpdate(PermissionUpdate_Req permission);
    }

}