using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<int> RoleCreate(RoleCreate role);
        Task<bool> RoleDelete(int roleId);
        Task<List<RoleGet>> RoleGetAll();
        Task<RoleGet?> RoleGetById(int roleId);
        Task<RoleGet?> RoleGetByName(string name);
        Task<bool> RoleUpdate(int roleId, RoleUpdate role);
    }
}