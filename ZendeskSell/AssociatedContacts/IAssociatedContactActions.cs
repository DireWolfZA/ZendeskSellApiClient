using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.AssociatedContacts {
    public interface IAssociatedContactActions {
        Task<ZendeskSellCollectionResponse<AssociatedContactResponse>> GetAsync(int pageNumber, int numPerPage, long dealID);
        Task<ZendeskSellObjectResponse<AssociatedContactResponse>> CreateAsync(long dealID, AssociatedContactRequest association);
        Task<ZendeskSellDeleteResponse> DeleteAsync(long dealID, long contactID);
    }
}
