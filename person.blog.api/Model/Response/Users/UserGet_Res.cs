using PersonBlogApi.Models.Roles;
using PersonBlogApi.Models.UserProfiles;

namespace PersonBlogApi.Models.Users
{
    public class UserGet_Res
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserProfileGet_Res? UserProfile { get; set; }
         public List<RoleGet_Res>? Roles { get; set; }
    }
}