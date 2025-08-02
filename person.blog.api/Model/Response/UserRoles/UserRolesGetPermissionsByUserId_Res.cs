namespace PersonBlogApi.Models.Permissions
{
    public class UserRolesGetPermissionsByUserId_Res
    {
        public int PermissionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}