

using PersonBlogApi.Models.SocialLogins;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ISocialLoginRepository
    {
        Task<int> SocialLoginCreate_Req(SocialLoginCreate_Req socialLogin);
        Task<bool> SocialLoginDelete(int socialLoginId);
        Task<SocialLoginGet_Req?> SocialLoginGet_ReqById(int socialLoginId);
        Task<SocialLoginGet_Req?> SocialLoginGet_ReqByProviderAndKey(string provider, string providerKey);
        Task<List<SocialLoginGet_Req>> SocialLoginGet_ReqByUserId(int userId);
    }
}