namespace PersonBlogApi.Models.UserProfiles
{
    public class UserProfileGet
    {
        public int UserProfileId { get; set; } // Primary key of UserProfiles table
        public int UserId { get; set; } // Foreign key to Users table
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}