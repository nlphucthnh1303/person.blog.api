namespace PersonBlogApi.Model.Categories
{
    public class CategoryCreate
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty; // Unique slug for URL
        public int? ParentCategoryId { get; set; } // Nullable if top-level
    }
}