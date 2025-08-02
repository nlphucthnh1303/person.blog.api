using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace ersonBlogApi.Services
{
    public abstract class BaseService
    {
        private readonly string _connectionString;

        // IConfiguration sẽ được inject tự động bởi DI container
        protected BaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        // Phương thức tạo một MySqlConnection mới
        // Dapper sẽ tự động mở và đóng kết nối nếu bạn truyền nó vào.
        // MySqlConnector sử dụng Connection Pooling để tối ưu việc tái sử dụng kết nối.
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}