namespace PersonBlogApi.Models.Posts
{
    public class PostUpdate_Req
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Slug { get; set; }
        public int? CategoryId { get; set; }
    }
}