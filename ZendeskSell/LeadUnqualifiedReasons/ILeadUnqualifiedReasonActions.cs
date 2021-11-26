using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.LeadUnqualifiedReasons {
    public interface ILeadUnqualifiedReasonActions {
        Task<ZendeskSellCollectionResponse<LeadUnqualifiedReasonResponse>> GetAsync(int pageNumber, int numPerPage);
    }
}
