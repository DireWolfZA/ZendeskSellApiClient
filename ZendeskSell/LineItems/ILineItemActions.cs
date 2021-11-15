using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.LineItems {
    public interface ILineItemActions {
        Task<ZendeskSellCollectionResponse<LineItemResponse>> GetAsync(int orderID, int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<LineItemResponse>> GetOneAsync(int orderID, int lineItemID);
        Task<ZendeskSellObjectResponse<LineItemResponse>> CreateAsync(int orderID, LineItemRequest lineItem);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int orderID, int lineItemID);
    }
}
