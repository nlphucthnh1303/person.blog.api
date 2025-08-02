namespace PersonBlogApi.Models.Posts
{
    public class PostUpdate_Req
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; } = "Draft";
        
    }
}