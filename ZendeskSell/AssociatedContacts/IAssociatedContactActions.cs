using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.AssociatedContacts {
    public interface IAssociatedContactActions {
        Task<ZendeskSellCollectionResponse<AssociatedContactResponse>> GetAsync(int pageNumber, int numPerPage, int dealID);
        Task<ZendeskSellObjectResponse<AssociatedContactResponse>> CreateAsync(int dealID, AssociatedContactRequest association);
        Task<ZendeskSellDeleteResponse> DeleteAsync(int dealID, int contactID);
    }
}
