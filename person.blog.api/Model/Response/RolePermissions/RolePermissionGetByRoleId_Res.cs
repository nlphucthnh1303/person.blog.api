namespace PersonBlogApi.Models.Roles
{
    public class RolePermissionGetByRoleId_Res
    {
        public int PermissionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}