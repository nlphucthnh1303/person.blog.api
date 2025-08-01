// Repositories/Implementations/CategoryService.cs
using Dapper;
using ersonBlogApi.Repositories;
using PersonBlogApi.Model.Categories;
using PersonBlogApi.Repositories.Interfaces;

namespace PersonBlogApi.Repositories.Implementations
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IConfiguration configuration) : base(configuration) { }

        public async Task<int> CategoryCreate(CategoryCreate category)
        {
            using (var connection = GetConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<int>(
                    "sp_Categories_Create",
                    category,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }


        public async Task<bool> CategoryDelete(int categoryId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_CategoryId = categoryId };
                var affectedRows = await connection.ExecuteAsync(
                    "sp_Categories_Delete",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }

        public async Task<List<CategoryGet>> CategoryGetAll()
        {
            using (var connection = GetConnection())
            {
                return (await connection.QueryAsync<CategoryGet>(
                    "sp_Categories_GetAll",
                    commandType: System.Data.CommandType.StoredProcedure
                )).ToList();
            }
        }

        public async Task<CategoryGet?> CategoryGetById(int categoryId)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_CategoryId = categoryId };
                return await connection.QueryFirstOrDefaultAsync<CategoryGet>(
                    "sp_Categories_GetById",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<CategoryGet?> CategoryGetBySlug(string slug)
        {
            using (var connection = GetConnection())
            {
                var parameters = new { p_Slug = slug };
                return await connection.QueryFirstOrDefaultAsync<CategoryGet>(
                    "sp_Categories_GetBySlug",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
            }
        }

        public async Task<bool> CategoryUpdate(int categoryId, CategoryUpdate category)
        {
            using (var connection = GetConnection())
            {
                // Create dynamic parameters or extend CategoryUpdateDto to include CategoryId
                var parameters = new DynamicParameters();
                parameters.Add("p_CategoryId", categoryId);
                parameters.Add("p_Name", category.Name);
                parameters.Add("p_Slug", category.Slug);
                parameters.Add("p_ParentCategoryId", category.ParentCategoryId);

                var affectedRows = await connection.ExecuteAsync(
                    "sp_Categories_Update",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return affectedRows > 0;
            }
        }
    }
}