namespace PersonBlogApi.Models.UserRoles
{
    public class UserRoleGet_Req
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty; // Join từ bảng Roles
    }
}