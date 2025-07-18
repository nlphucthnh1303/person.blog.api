// Repositories/Interfaces/IUserRepository.cs

using PersonBlogApi.Models.Users;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserGet?> GetUserById(int userId);
        Task<UserGet?> GetUserByUsername(string username);
        Task<UserGet?> GetUserByEmail(string email); // Hàm này đã được đề cập
        Task<bool> UpdateUserPassword(int userId, string newPasswordHash); // Cập nhật mật khẩu
        Task<bool> SetEmailConfirmed(int userId, bool isConfirmed); // Cập nhật trạng thái email xác nhận
        Task<bool> UserDelete(int userId); // Soft delete
        Task<int> UserCreate(UserCreate userCreate); // Soft delete
    }
}