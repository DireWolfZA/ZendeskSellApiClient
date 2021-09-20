using System.Collections.Generic;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Leads {
    public interface ILeadActions {
        Task<ZendeskSellCollectionResponse<LeadResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null, string email = null, string phone = null, string mobile = null, int? ownerID = null);
        Task<ZendeskSellObjectResponse<LeadResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<LeadResponse>> CreateAsync(LeadRequest lead);
        Task<ZendeskSellObjectResponse<LeadResponse>> UpdateAsync(int id, LeadRequest lead);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
