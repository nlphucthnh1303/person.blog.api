namespace PersonBlogApi.Models.PostTags
{
    public class PostTagGet 
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; } = string.Empty; // Join từ bảng Tags
        public string TagSlug { get; set; } = string.Empty;
    }
}