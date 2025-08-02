
namespace PersonBlogApi.Models.Users
{
    public class UserCreate_Req
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}