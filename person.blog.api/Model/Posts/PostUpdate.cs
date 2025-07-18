namespace PersonBlogApi.Models.Posts
{
    public class PostUpdate
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public int? CategoryId { get; set; }
    }
}