using System.Collections.Generic;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Deals {
    public interface IDealActions {
        Task<ZendeskSellCollectionResponse<DealResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null, int? ownerID = null, int? stageID = null);
        Task<ZendeskSellObjectResponse<DealResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<DealResponse>> CreateAsync(DealRequest deal);
        Task<ZendeskSellObjectResponse<DealResponse>> UpdateAsync(int id, DealRequest deal);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
