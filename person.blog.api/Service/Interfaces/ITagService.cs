

using PersonBlogApi.Models.Tags;

namespace PersonBlogApi.Repositories.Interfaces
{
    public interface ITagService
    {
        Task<int> TagCreate_Req(TagCreate_Req tag);
        Task<bool> TagDelete(int tagId);
        Task<List<TagGet_Req>> TagGet_ReqAll();
        Task<TagGet_Req?> TagGet_ReqById(int tagId);
        Task<TagGet_Req?> TagGet_ReqBySlug(string slug);
        Task<bool> TagUpdate_Req(int tagId, TagUpdate_Req tag);
    }
}