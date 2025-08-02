namespace PersonBlogApi.Models.Posts
{
    public class PostGetPublishedList_Res
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AuthorUsername { get; set; }
        public string? CategoryName { get; set; }
        // Các trường tóm tắt khác (ví dụ: một phần nội dung, ảnh bìa...)
    }
}