
using PersonBlogApi.Models.UserProfiles;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<int> UserProfileCreate_Req(UserProfileCreate_Req profile);
        Task<UserProfileGet_Req?> UserProfileGet_ReqByUserId(int userId);
        Task<bool> UserProfileUpdate_Req(int userId, UserProfileUpdate_Req profile);
        Task<bool> UserProfileUpdateUserId_Req(int oldUserId, int newUserId); // Cập nhật FK UserId
    }
}