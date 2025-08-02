namespace PersonBlogApi.Models.Roles
{
    public class RoleGetAll_Res
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}