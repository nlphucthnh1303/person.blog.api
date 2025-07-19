namespace PersonBlogApi.Models.UserProfiles
{
    public class UserProfileCreate_Req
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}