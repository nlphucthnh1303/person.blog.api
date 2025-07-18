// Extensions/ServiceCollectionExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonBlogApi.Services.Interfaces;
using PersonBlogApi.Services.Implementations;
using PersonBlogApi.Repositories;
using PersonBlogApi.Repositories.Interfaces;
using PersonBlogApi.Repositories.Implementations;

namespace PersonBlogApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // Phương thức mở rộng để đăng ký tất cả các Repositories
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            // Đảm bảo bạn đã có các Repository này và interface tương ứng
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentLikeRepository, CommentLikeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            return services;
        }

        // Phương thức mở rộng để đăng ký tất cả các Business Services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Đảm bảo bạn đã có các Service này và interface tương ứng
            services.AddScoped<IAuthService, AuthService>();
            // services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IPostService, PostService>();
            // services.AddScoped<ICategoryService, CategoryService>();
            // services.AddScoped<ITagService, TagService>();
            // services.AddScoped<ICommentService, CommentService>();

            return services;
        }

        // Phương thức tổng hợp để đăng ký cả hai loại trên,
        // hoặc thêm các dịch vụ khác (như xác thực JWT, v.v.)
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Bạn có thể đặt logic kiểm tra chuỗi kết nối ở đây hoặc trong BaseRepository
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            }

            services.AddApplicationRepositories(); // Gọi phương thức đã định nghĩa ở trên
            services.AddApplicationServices();    // Gọi phương thức đã định nghĩa ở trên

            // Đăng ký các tiện ích (Utilities) nếu cần inject
            // services.AddScoped<IPasswordHasher, PasswordHasher>();
            // services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}