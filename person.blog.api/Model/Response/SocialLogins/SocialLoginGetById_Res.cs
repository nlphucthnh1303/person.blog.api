namespace PersonBlogApi.Models.SocialLogins
{
    public class SocialLoginetByUserId_Res
    {
        public int SocialLoginId { get; set; }
        public int UserId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }



}