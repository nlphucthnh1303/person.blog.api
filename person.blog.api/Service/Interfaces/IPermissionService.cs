

using PersonBlogApi.Models.Permissions;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<int> PermissionCreate_Req(PermissionCreate_Req permission);
        Task<bool> PermissionDelete(int permissionId);
        Task<List<PermissionGet_Req>> PermissionGet_ReqAll();
        Task<PermissionGet_Req?> PermissionGet_ReqById(int permissionId);
        Task<PermissionGet_Req?> PermissionGet_ReqByName(string name);
        Task<bool> PermissionUpdate_Req(int permissionId, PermissionUpdate_Req permission);
    }
}