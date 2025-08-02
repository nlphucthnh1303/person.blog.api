// Services/Implementations/RoleService.cs
using Dapper;
using ersonBlogApi.Services;
using PersonBlogApi.Models.Roles;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Services.Implementations
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> RoleCreate(RoleCreate_Req role)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Name", role.Name);
                parameters.Add("p_Description", role.Description);
                return await connection.ExecuteAsync(
                    "sp_Roles_Create",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> RoleDelete(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Roles_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<RoleGetAll_Res>> RoleGetAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<RoleGetAll_Res>(
                    "sp_Roles_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<RoleGetById_Res?> RoleGetById(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                return await connection.QueryFirstOrDefaultAsync<RoleGetById_Res>(
                    "sp_Roles_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<RoleGetByName_Res?> RoleGetByName(string name)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Name = name };
                return await connection.QueryFirstOrDefaultAsync<RoleGetByName_Res>(
                    "sp_Roles_GetByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> RoleUpdate(int roleId, RoleUpdate_Req role)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_RoleId", roleId);
                parameters.Add("p_Name", role.Name);
                parameters.Add("p_Description", role.Description);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Roles_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }




    }
}