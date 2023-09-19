using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Tasks {
    public interface ITaskActions {
        Task<ZendeskSellCollectionResponse<TaskResponse>> GetAsync(int pageNumber, int numPerPage, long? resourceID = null, string resourceType = null);
        Task<ZendeskSellObjectResponse<TaskResponse>> GetOneAsync(long id);
        Task<ZendeskSellObjectResponse<TaskResponse>> CreateAsync(TaskRequest task);
        Task<ZendeskSellObjectResponse<TaskResponse>> UpdateAsync(long id, TaskRequest task);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(long id);
    }
}
