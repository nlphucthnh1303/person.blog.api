// Repositories/Implementations/UserProfileService.cs
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.UserProfiles;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories.Implementations
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        public UserProfileService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> UserProfileCreate(UserProfileCreate_Req profile)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_UserProfiles_Create",
                    profile,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<UserProfileGet_Req?> UserProfileGetByUserId(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId };
                return await connection.QueryFirstOrDefaultAsync<UserProfileGet_Req>(
                    "sp_UserProfiles_GetByUserId",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> UserProfileUpdate(int userId, UserProfileUpdate_Req profile)
        {
            using (var connection = GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_UserId", userId);
                parameters.Add("p_FirstName", profile.FirstName);
                parameters.Add("p_LastName", profile.LastName);
                parameters.Add("p_Bio", profile.Bio);
                parameters.Add("p_ProfilePictureUrl", profile.ProfilePictureUrl);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_UserProfiles_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<bool> UserProfileUpdateUserId(int oldUserId, int newUserId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new UserProfileUpdateUserId_Req
                {
                    OldUserId = oldUserId,
                    NewUserId = newUserId
                };
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

        public Task<bool> UserProfileUpdateUserId(int newUserId)
        {
            throw new NotImplementedException();
        }
    }
}