

using PersonBlogApi.Models.Tags;

namespace PersonBlogApi.Services.Interfaces
{
    public interface ITagService
    {
        Task<int> TagCreate(TagCreate_Req tag);
        Task<bool> TagDelete(int tagId);
        Task<bool> TagUpdate(int tagId, TagUpdate_Req tag);
        Task<List<TagGetAll_Res>> TagGetAll();
        Task<TagGetById_Res?> TagGetById(int tagId);
        Task<TagGetBySlug_Res?> TagGetBySlug(string slug);
       
    }


    // sp_Tags_Create
    // sp_Tags_Delete
    // sp_Tags_GetAll
    // sp_Tags_GetById
    // sp_Tags_GetBySlug
    // sp_Tags_Update
}