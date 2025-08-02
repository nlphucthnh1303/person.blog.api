namespace PersonBlogApi.Models.Comments
{
    public class CommentGetByPostId_Res
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? ParentCommentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? AuthorUsername { get; set; }
         public string? AuthorAvatarUrl { get; set; }
    }

    

}