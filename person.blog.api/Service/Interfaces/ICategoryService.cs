using PersonBlogApi.Model.Categories;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CategoryCreate(CategoryCreate category);
        Task<bool> CategoryDelete(int categoryId);
        Task<List<CategoryGet>> CategoryGetAll();
        Task<CategoryGet?> CategoryGetById(int categoryId);
        Task<CategoryGet?> CategoryGetBySlug(string slug);
        Task<bool> CategoryUpdate(int categoryId, CategoryUpdate category);
    }
}