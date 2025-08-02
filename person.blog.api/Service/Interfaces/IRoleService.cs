using PersonBlogApi.Models.Roles;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task<int> RoleCreate(RoleCreate_Req role);
        Task<bool> RoleDelete(int roleId);
        Task<List<RoleGetAll_Res>> RoleGetAll();
        Task<RoleGetById_Res?> RoleGetById(int roleId);
        Task<RoleGetByName_Res?> RoleGetByName(string name);
        Task<bool> RoleUpdate(int roleId, RoleUpdate_Req role);

        // sp_Roles_Create
        // sp_Roles_Delete
        // sp_Roles_GetAll
        // sp_Roles_GetById
        // sp_Roles_GetByName
        // sp_Roles_Update


    }
}