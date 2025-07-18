namespace PersonBlogApi.Models.SocialLogins
{
    public class SocialLoginGet
    {
        public int SocialLoginId { get; set; }
        public int UserId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}