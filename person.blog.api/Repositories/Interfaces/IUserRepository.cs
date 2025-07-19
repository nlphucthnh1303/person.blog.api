// Repositories/Interfaces/IUserRepository.cs

using PersonBlogApi.Models.Users;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserGet_Req?> GetUserById(int userId);
        Task<UserGet_Req?> GetUserByUsername(string username);
        Task<UserGet_Req?> GetUserByEmail(string email); // Hàm này đã được đề cập
        Task<bool> UpdateUserPassword(int userId, string newPasswordHash); // Cập nhật mật khẩu
        Task<bool> SetEmailConfirmed(int userId, bool isConfirmed); // Cập nhật trạng thái email xác nhận
        Task<bool> UserDelete_Req(int userId); // Soft delete
        Task<int> UserCreate_Req(UserCreate_Req UserCreate_Req); // Soft delete
    }
}