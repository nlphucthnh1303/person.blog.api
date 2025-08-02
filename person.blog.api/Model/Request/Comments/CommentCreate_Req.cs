namespace PersonBlogApi.Models.Comments
{
    public class CommentCreate_Req
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? ParentCommentId { get; set; }
    }
}