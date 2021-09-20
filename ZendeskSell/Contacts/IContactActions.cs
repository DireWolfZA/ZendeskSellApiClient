using System.Collections.Generic;
using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.Contacts {
    public interface IContactActions {
        Task<ZendeskSellCollectionResponse<ContactResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null, string email = null, string phone = null, string mobile = null);
        Task<ZendeskSellObjectResponse<ContactResponse>> GetOneAsync(int id);
        Task<ZendeskSellObjectResponse<ContactResponse>> CreateAsync(ContactRequest contact);
        Task<ZendeskSellObjectResponse<ContactResponse>> UpdateAsync(int id, ContactRequest contact);
        /// <returns><see langword="null"/> on success</returns>
        Task<ZendeskSellDeleteResponse> DeleteAsync(int id);
    }
}
