using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IRoleService
    {
        Task<int> RoleCreate_Req(RoleCreate_Req role);
        Task<bool> RoleDelete(int roleId);
        Task<List<RoleGet_Req>> RoleGet_ReqAll();
        Task<RoleGet_Req?> RoleGet_ReqById(int roleId);
        Task<RoleGet_Req?> RoleGet_ReqByName(string name);
        Task<bool> RoleUpdate_Req(int roleId, RoleUpdate_Req role);
    }
}