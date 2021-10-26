using System.Threading.Tasks;
using ZendeskSell.Models;

namespace ZendeskSell.CustomFields {
    public interface ICustomFieldActions {
        Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetLeads();
        Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetContacts();
        Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetDeals();
        Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetProspectAndCustomers();
    }
}
