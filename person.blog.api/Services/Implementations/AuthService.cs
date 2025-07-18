// Services/Implementations/AuthService.cs
using PersonBlogApi.Services.Interfaces;
using PersonBlogApi.Repositories;
using BCrypt.Net;
using PersonBlogApi.Controllers;
using PersonBlogApi.Models.Auth; // Để băm mật khẩu

namespace PersonBlogApi.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        // Nếu có JWT, bạn có thể inject IConfiguration hoặc JwtTokenGenerator ở đây
        // private readonly IConfiguration _configuration;
        // private readonly JwtTokenGenerator _tokenGenerator;

        public AuthService(UserRepository userRepository /*, IConfiguration configuration, JwtTokenGenerator tokenGenerator */)
        {
            _userRepository = userRepository;
            // _configuration = configuration;
            // _tokenGenerator = tokenGenerator;
        }

     

        
    }
}