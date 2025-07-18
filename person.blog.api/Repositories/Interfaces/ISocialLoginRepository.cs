

using PersonBlogApi.Models.SocialLogins;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ISocialLoginRepository
    {
        Task<int> SocialLoginCreate(SocialLoginCreate socialLogin);
        Task<bool> SocialLoginDelete(int socialLoginId);
        Task<SocialLoginGet?> SocialLoginGetById(int socialLoginId);
        Task<SocialLoginGet?> SocialLoginGetByProviderAndKey(string provider, string providerKey);
        Task<List<SocialLoginGet>> SocialLoginGetByUserId(int userId);
    }
}