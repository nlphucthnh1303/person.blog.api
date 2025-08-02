namespace PersonBlogApi.Models.RolePermissions
{
    public class RolePermissionGet_Req
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; } = string.Empty; // Join từ bảng Permissions
    }
}