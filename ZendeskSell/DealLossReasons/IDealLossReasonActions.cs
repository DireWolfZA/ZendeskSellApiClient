using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.DealLossReasons {
    public interface IDealLossReasonActions {
        Task<ZendeskSellCollectionResponse<DealLossReasonResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<DealLossReasonResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<DealLossReasonResponse>> CreateAsync(DealLossReasonRequest reason);
        Task<ZendeskSellObjectResponse<DealLossReasonResponse>> UpdateAsync(int id, DealLossReasonRequest reason);
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
