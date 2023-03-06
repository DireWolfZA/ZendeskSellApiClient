using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Orders {
    public interface IOrderActions {
        Task<ZendeskSellCollectionResponse<OrderResponse>> GetAsync(int pageNumber, int numPerPage, long? dealID = null);
        Task<ZendeskSellObjectResponse<OrderResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<OrderResponse>> CreateAsync(OrderRequest order);
        Task<ZendeskSellObjectResponse<OrderResponse>> UpdateAsync(int id, OrderRequest order);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
