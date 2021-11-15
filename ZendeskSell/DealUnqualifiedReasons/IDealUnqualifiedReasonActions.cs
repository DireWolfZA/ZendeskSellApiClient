using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.DealUnqualifiedReasons {
    public interface IDealUnqualifiedReasonActions {
        Task<ZendeskSellCollectionResponse<DealUnqualifiedReasonResponse>> GetAsync(int pageNumber, int numPerPage);
        Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> CreateAsync(DealUnqualifiedReasonRequest reason);
        Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> UpdateAsync(int id, DealUnqualifiedReasonRequest reason);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
