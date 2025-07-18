

using PersonBlogApi.Models.Tags;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<int> TagCreate(TagCreate tag);
        Task<bool> TagDelete(int tagId);
        Task<List<TagGet>> TagGetAll();
        Task<TagGet?> TagGetById(int tagId);
        Task<TagGet?> TagGetBySlug(string slug);
        Task<bool> TagUpdate(int tagId, TagUpdate tag);
    }
}