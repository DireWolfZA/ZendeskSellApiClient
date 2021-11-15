using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Tasks {
    public interface ITaskActions {
        Task<ZendeskSellCollectionResponse<TaskResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<TaskResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<TaskResponse>> CreateAsync(TaskRequest task);
        Task<ZendeskSellObjectResponse<TaskResponse>> UpdateAsync(int id, TaskRequest task);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
