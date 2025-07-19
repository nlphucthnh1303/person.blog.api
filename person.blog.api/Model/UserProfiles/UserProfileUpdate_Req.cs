namespace PersonBlogApi.Models.UserProfiles
{
    public class UserProfileUpdate_Req
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}