// Extensions/ServiceCollectionExtensions.cs
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            // Đảm bảo bạn đã có các Service này và interface tương ứng
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentLikeService, CommentLikeService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            return services;
        }

        // Phương thức mở rộng để đăng ký tất cả các Business Services
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Đảm bảo bạn đã có các Service này và interface tương ứng
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
            // Bạn có thể đặt logic kiểm tra chuỗi kết nối ở đây hoặc trong BaseService
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