using PersonBlogApi.Model.Categories;

namespace PersonBlogApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CategoryCreate(CategoryCreate category);
        Task<bool> CategoryDelete(int categoryId);
        Task<List<CategoryGetAll_Res>> CategoryGetAll();
        Task<CategoryGetById_Res?> CategoryGetById(int categoryId);
        Task<CategoryGetBySlug_Res?> CategoryGetBySlug(string slug);
        Task<bool> CategoryUpdate(CategoryUpdate category);
    }
}