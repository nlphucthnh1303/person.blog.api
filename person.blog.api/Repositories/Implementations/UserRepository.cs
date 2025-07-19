
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Models.Users;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<UserGet_Req?> GetUserById(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId }; // Tên tham số khớp với SP
                return await connection.QueryFirstOrDefaultAsync<UserGet_Req>(
                    "sp_Users_GetById", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<UserGet_Req?> GetUserByUsername(string username)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Username = username }; // Tên tham số khớp với SP
                return await connection.QueryFirstOrDefaultAsync<UserGet_Req>(
                    "sp_Users_GetByUsername", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<UserGet_Req?> GetUserByEmail(string email)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Email = email }; // Tên tham số khớp với SP
                return await connection.QueryFirstOrDefaultAsync<UserGet_Req>(
                    "sp_Users_GetByEmail", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> UpdateUserPassword(int userId, string newPasswordHash)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_UserId = userId,
                    p_NewPasswordHash = newPasswordHash // Tên tham số khớp với SP
                };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Users_UpdatePassword", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0; // Trả về true nếu có hàng bị ảnh hưởng
            }
        }

        public async Task<bool> SetEmailConfirmed(int userId, bool isConfirmed)
        {
            using (var connection = GetConnection())
            {
                var parameters = new
                {
                    p_UserId = userId,
                    p_IsEmailConfirmed = isConfirmed // Tên tham số khớp với SP
                };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Users_SetEmailConfirmed", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0; // Trả về true nếu có hàng bị ảnh hưởng
            }
        }

        public async Task<bool> UserDelete_Req(int userId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_UserId = userId }; // Tên tham số khớp với SP
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Users_Delete", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0; // Trả về true nếu có hàng bị ảnh hưởng
            }
        }

        public async Task<int> UserCreate_Req(UserCreate_Req UserCreate_Req)
        {
            //Sử dụng 'using' để đảm bảo MySqlConnection được đóng và giải phóng đúng cách.
            using (var connection = GetConnection())
            {
                // Tạo một đối tượng ẩn danh để truyền tham số cho Stored Procedure.
                // Tên thuộc tính phải khớp với tên tham số của SP (ví dụ: p_Username).
                var parameters = new
                {
                    p_Username = UserCreate_Req.Username,
                    p_Email = UserCreate_Req.Email,
                    p_PasswordHash = UserCreate_Req.PasswordHash
                };

                // QuerySingleOrDefaultAsync<T>: Dùng khi SP trả về một giá trị duy nhất (như ID mới).
                var newUserId = await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Users_Create", // Tên Stored Procedure
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure // Quan trọng: Chỉ định là Stored Procedure
                );
                return newUserId;
            }
        }

    }
}