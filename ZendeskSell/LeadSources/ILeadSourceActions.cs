using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.LeadSources {
    public interface ILeadSourceActions {
        Task<ZendeskSellCollectionResponse<LeadSourceResponse>> GetAsync(int pageNumber, int numPerPage, string name = null);
        Task<ZendeskSellObjectResponse<LeadSourceResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<LeadSourceResponse>> CreateAsync(LeadSourceRequest dealSource);
        Task<ZendeskSellObjectResponse<LeadSourceResponse>> UpdateAsync(int id, LeadSourceRequest dealSource);
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
