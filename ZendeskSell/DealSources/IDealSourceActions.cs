using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.DealSources {
    public interface IDealSourceActions {
        Task<ZendeskSellCollectionResponse<DealSourceResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<DealSourceResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<DealSourceResponse>> CreateAsync(DealSourceRequest dealSource);
        Task<ZendeskSellObjectResponse<DealSourceResponse>> UpdateAsync(int id, DealSourceRequest dealSource);
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
