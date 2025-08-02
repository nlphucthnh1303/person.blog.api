

using PersonBlogApi.Models.Posts;

namespace PersonBlogApi.Services.Interfaces
{
    public interface IPostService
    {
        Task<int> PostCreate(PostCreate_Req post);
        Task<bool> PostDelete(int postId);
        Task<bool> PostUpdate(PostUpdate_Req post);
        Task<PostGetById_Res?> PostGetById(int postId);
        Task<PostGetBySlug_Res?> PostGetBySlug(string slug);
        Task<List<PostGetPublishedList_Res>> PostGetPublishedList(int pageNumber, int pageSize);
        Task<bool> PostIncrementViewCount(int postId);
        Task<bool> PostUpdateStatus(int postId, string status);
    }

    // sp_Posts_Create
    // sp_Posts_Delete
    // sp_Posts_Update
    // sp_Posts_GetById
    // sp_Posts_GetBySlug
    // sp_Posts_GetPublishedList
    // sp_Posts_IncrementViewCount
    // sp_Posts_UpdateStatus



}