namespace PersonBlogApi.Models.SocialLogins
{
    public class SocialLoginCreate_Req
    {
        public int UserId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
    }



}