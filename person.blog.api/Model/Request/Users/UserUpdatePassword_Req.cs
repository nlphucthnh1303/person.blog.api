namespace PersonBlogApi.Models.Users
{
    public class UserUpdatePassword_Req
    {
        public int userId { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
    }
}