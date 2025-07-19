namespace PersonBlogApi.Models.SocialLogins
{
    public class SocialLoginCreate_Req
    {
        public int UserId { get; set; }
        public string Provider { get; set; } = string.Empty; // e.g., "Google", "Facebook"
        public string ProviderKey { get; set; } = string.Empty; // User ID from social provider
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}