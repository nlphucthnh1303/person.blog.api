namespace  PersonBlogApi.Models.Comments
{
    public class CommentUpdate_Req
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}