

using PersonBlogApi.Models.SocialLogins;

namespace PersonBlogApi.Services.Interfaces
{
    public interface ISocialLoginService
    {
        Task<int> SocialLoginCreate(SocialLoginCreate_Req socialLogin);
        Task<bool> SocialLoginDelete(int socialLoginId);
        Task<SocialLoginGetById_Res?> SocialLoginGetById(int socialLoginId);
        Task<SocialLoginGetByProviderNameAndKey_Res?> SocialLoginGetByProviderNameAndKey(string providerName, string providerKey);
        Task<List<SocialLoginetByUserId_Res>> SocialLoginGetByUserId(int userId);
    }
}