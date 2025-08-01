
using PersonBlogApi.Models.UserProfiles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserProfileService
    {
        Task<int> UserProfileCreate(UserProfileCreate_Req profile);
        Task<bool> UserProfileDelete(int userId);
        Task<UserProfileGet_Req?> UserProfileGetByUserId(int userId);
        Task<bool> UserProfileUpdate(int userId, UserProfileUpdate_Req profile);
        Task<bool> UserProfileUpdateUserId(int newUserId); // Cập nhật FK UserId
    }
}