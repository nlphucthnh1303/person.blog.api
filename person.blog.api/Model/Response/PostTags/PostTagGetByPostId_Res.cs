namespace PersonBlogApi.Models.Roles
{
    public class PostTagGetByPostId_Res
    {
        public int TagId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}