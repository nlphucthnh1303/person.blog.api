// Services/Implementations/UserProfileService.cs
using Dapper;
using ersonBlogApi.Services;
using PersonBlogApi.Models.UserProfiles;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Services.Implementations
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        public UserProfileService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> UserProfileCreate(UserProfileCreate_Req req)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_UserId", req);
                parameters.Add("p_FirstName", req.FirstName);
                parameters.Add("p_LastName", req.LastName);
                parameters.Add("p_FirstName", req.FirstName);
                parameters.Add("p_AvatarUrl", req.AvatarUrl);
                parameters.Add("p_Bio", req.Bio);
                parameters.Add("p_DateOfBirth", req.DateOfBirth);
                parameters.Add("p_PhoneNumber", req.PhoneNumber);
                parameters.Add("p_Country", req.Country);
                parameters.Add("p_FacebookLink", req.FacebookLink);
                parameters.Add("p_TwitterLink", req.TwitterLink);
                parameters.Add("p_LinkedInLink", req.LinkedInLink);
                parameters.Add("p_GitHubLink", req.GitHubLink);
                return await connection.ExecuteAsync(
                    "sp_UserProfiles_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<UserProfileGetByUserId_Res?> UserProfileGetByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                return await connection.QueryFirstOrDefaultAsync<UserProfileGetByUserId_Res>(
                    "sp_UserProfiles_GetByUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> UserProfileUpdate(UserProfileUpdate_Req req)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_UserProfileId", req.UserProfileId);
                parameters.Add("p_FirstName", req.FirstName);
                parameters.Add("p_LastName", req.LastName);
                parameters.Add("p_AvatarUrl", req.AvatarUrl);
                parameters.Add("p_Bio", req.Bio);
                parameters.Add("p_DateOfBirth", req.DateOfBirth);
                parameters.Add("p_PhoneNumber", req.PhoneNumber);
                parameters.Add("p_Country", req.Country);
                parameters.Add("p_FacebookLink", req.FacebookLink);
                parameters.Add("p_TwitterLink", req.TwitterLink);
                parameters.Add("p_LinkedInLink", req.LinkedInLink);
                parameters.Add("p_GitHubLink", req.GitHubLink);
                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserProfiles_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<bool> UserProfileUpdateUserId(UserProfileUpdateUserId_Req req)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_UserId", req.UserId);
                parameters.Add("p_FirstName", req.FirstName);
                parameters.Add("p_LastName", req.LastName);
                parameters.Add("p_AvatarUrl", req.AvatarUrl);
                parameters.Add("p_Bio", req.Bio);
                parameters.Add("p_DateOfBirth", req.DateOfBirth);
                parameters.Add("p_PhoneNumber", req.PhoneNumber);
                parameters.Add("p_Country", req.Country);
                parameters.Add("p_FacebookLink", req.FacebookLink);
                parameters.Add("p_TwitterLink", req.TwitterLink);
                parameters.Add("p_LinkedInLink", req.LinkedInLink);
                parameters.Add("p_GitHubLink", req.GitHubLink);
                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserProfiles_UpdateUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }


        public async Task<bool> UserProfileDelete(int userProfileId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserProfileId = userProfileId }; // Tên tham số khớp với SP
                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserProfiles_Delete", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0; // Trả về true nếu có hàng bị ảnh hưởng
            }
        }

        
    }
}