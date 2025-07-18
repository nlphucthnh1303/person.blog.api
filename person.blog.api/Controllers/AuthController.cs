// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using PersonBlogApi.Models.Auth;
using PersonBlogApi.Services.Interfaces;

namespace PersonBlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService; // Inject Interface

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }





    }

    public class AuthResponse
    {
        public string? Message { get; set; }
        public int UserId { get; set; }
    }
}