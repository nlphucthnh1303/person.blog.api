// Services/Implementations/SocialLoginService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Services.Interfaces;
using ersonBlogApi.Services;
using PersonBlogApi.Models.SocialLogins;

namespace PersonBlogApi.Services.Implementations
{
    public class SocialLoginService : BaseService, ISocialLoginService
    {
        public SocialLoginService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> SocialLoginCreate(SocialLoginCreate_Req req)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_UserId", req.UserId);
                parameters.Add("p_ProviderName",  req.ProviderKey);
                parameters.Add("p_ProviderKey",  req.ProviderKey);
                parameters.Add("p_Email",  req.Email);
                parameters.Add("p_DisplayName",  req.DisplayName);
                parameters.Add("p_AvatarUrl",  req.AvatarUrl);
                return await connection.ExecuteAsync(
                    "sp_SocialLogins_Create",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> SocialLoginDelete(int socialLoginId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_SocialLoginId = socialLoginId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_SocialLogins_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<SocialLoginGetById_Res?> SocialLoginGetById(int socialLoginId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_SocialLoginId = socialLoginId };
                return await connection.QueryFirstOrDefaultAsync<SocialLoginGetById_Res>(
                    "sp_SocialLogins_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<SocialLoginGetByProviderNameAndKey_Res?> SocialLoginGetByProviderNameAndKey(string provider, string providerKey)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Provider = provider, p_ProviderKey = providerKey };
                return await connection.QueryFirstOrDefaultAsync<SocialLoginGetByProviderNameAndKey_Res>(
                    "sp_SocialLogins_GetByProviderAndKey",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<List<SocialLoginetByUserId_Res>> SocialLoginGetByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                return (await connection.QueryAsync<SocialLoginetByUserId_Res>(
                    "sp_SocialLogins_GetByUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

    }
}