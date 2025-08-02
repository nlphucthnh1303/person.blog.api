namespace PersonBlogApi.Model.Categories
{
    public class CategoryUpdate
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}