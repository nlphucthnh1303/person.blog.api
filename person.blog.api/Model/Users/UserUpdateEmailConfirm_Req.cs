namespace PersonBlogApi.Models.Users
{
    public class UserUpdateEmailConfirm_Req
    {
        public int userId { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}