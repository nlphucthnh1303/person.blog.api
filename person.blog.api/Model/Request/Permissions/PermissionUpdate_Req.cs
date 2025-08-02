namespace PersonBlogApi.Models.Permissions
{
    public class PermissionUpdate_Req
    {
        public int? PermissionId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}