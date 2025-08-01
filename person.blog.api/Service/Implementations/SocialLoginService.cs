// Repositories/Implementations/SocialLoginService.cs
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using PersonBlogApi.Repositories.Interfaces;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.SocialLogins;

namespace PersonBlogApi.Repositories.Implementations
{
    public class SocialLoginService : BaseService, ISocialLoginService
    {
        public SocialLoginService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> SocialLoginCreate_Req(SocialLoginCreate_Req socialLogin)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_SocialLogins_Create",
                    socialLogin,
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

        public async Task<SocialLoginGet_Req?> SocialLoginGet_ReqById(int socialLoginId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_SocialLoginId = socialLoginId };
                return await connection.QueryFirstOrDefaultAsync<SocialLoginGet_Req>(
                    "sp_SocialLogins_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<SocialLoginGet_Req?> SocialLoginGet_ReqByProviderAndKey(string provider, string providerKey)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Provider = provider, p_ProviderKey = providerKey };
                return await connection.QueryFirstOrDefaultAsync<SocialLoginGet_Req>(
                    "sp_SocialLogins_GetByProviderAndKey",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<List<SocialLoginGet_Req>> SocialLoginGet_ReqByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                return (await connection.QueryAsync<SocialLoginGet_Req>(
                    "sp_SocialLogins_GetByUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

    }
}