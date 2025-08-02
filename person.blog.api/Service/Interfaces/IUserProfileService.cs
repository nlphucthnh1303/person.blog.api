
using PersonBlogApi.Models.UserProfiles;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<int> UserProfileCreate(UserProfileCreate_Req req);
        Task<bool> UserProfileDelete(int userId);
        Task<UserProfileGetByUserId_Res?> UserProfileGetByUserId(int userId);
        Task<bool> UserProfileUpdate(UserProfileUpdate_Req req);
        Task<bool> UserProfileUpdateUserId( UserProfileUpdateUserId_Req req);
    }
    // sp_UserProfiles_Create
    // sp_UserProfiles_Delete
    // sp_UserProfiles_Update
    // sp_UserProfiles_UpdateUserId
    // sp_UserProfiles_GetByUserId



}