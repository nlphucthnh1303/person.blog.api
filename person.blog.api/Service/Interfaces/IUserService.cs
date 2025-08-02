// Services/Interfaces/IUserService.cs


using PersonBlogApi.Models.Users;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserGetById_Res?> GetUserById(int userId);
        Task<UserGetByUsername_Res?> GetUserByUsername(string username);
        Task<UserGetByEmail_Res?> GetUserByEmail(string email); // Hàm này đã được đề cập
        Task<bool> UpdateUserPassword(int userId, string newPasswordHash); // Cập nhật mật khẩu
        Task<bool> SetEmailConfirmed(int userId, bool isConfirmed); // Cập nhật trạng thái email xác nhận
        Task<bool> UserDelete(int userId); // Soft delete
        Task<int> UserCreate(UserCreate_Req UserCreate_Req); // Soft delete
    }


}