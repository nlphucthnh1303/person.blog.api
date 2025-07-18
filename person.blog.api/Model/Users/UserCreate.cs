namespace PersonBlogApi.Models.Users
{
    public class UserCreate
    {
        public string Username { get; set; } = string.Empty; // Tên property khớp với tham số SP
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Mật khẩu đã hash
    }

}