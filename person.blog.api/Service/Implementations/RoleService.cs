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

        public async Task<int> RoleCreate_Req(RoleCreate_Req role)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Roles_Create",
                    role,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> RoleDelete(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                // Giả định SP này thực hiện soft delete bằng cách set IsActive = FALSE hoặc IsDeleted = TRUE
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Roles_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<RoleGet_Req>> RoleGet_ReqAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<RoleGet_Req>(
                    "sp_Roles_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<RoleGet_Req?> RoleGet_ReqById(int roleId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_RoleId = roleId };
                return await connection.QueryFirstOrDefaultAsync<RoleGet_Req>(
                    "sp_Roles_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<RoleGet_Req?> RoleGet_ReqByName(string name)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Name = name };
                return await connection.QueryFirstOrDefaultAsync<RoleGet_Req>(
                    "sp_Roles_GetByName",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> RoleUpdate_Req(int roleId, RoleUpdate_Req role)
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