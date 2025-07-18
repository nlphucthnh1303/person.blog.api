
using PersonBlogApi.Models.UserProfiles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<int> UserProfileCreate(UserProfileCreate profile);
        Task<UserProfileGet?> UserProfileGetByUserId(int userId);
        Task<bool> UserProfileUpdate(int userId, UserProfileUpdate profile);
        Task<bool> UserProfileUpdateUserId(int oldUserId, int newUserId); // Cập nhật FK UserId
    }
}