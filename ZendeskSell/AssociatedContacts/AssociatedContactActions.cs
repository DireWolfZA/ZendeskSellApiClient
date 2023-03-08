using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developer.zendesk.com/api-reference/sales-crm/resources/associated-contacts/
namespace ZendeskSell.AssociatedContacts {
    public class AssociatedContactActions : IAssociatedContactActions {
        private RestClient _client;

        public AssociatedContactActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<AssociatedContactResponse>> GetAsync(int pageNumber, int numPerPage, long dealID) {
            var request = new RestRequest($"deals/{dealID}/associated_contacts", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<AssociatedContactResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<AssociatedContactResponse>> CreateAsync(long dealID, AssociatedContactRequest association) {
            Require.Argument("ContactID", association.ContactID == 0 ? null : (object)association.ContactID);
            association.Role = association.Role ?? "involved";

            var request = new RestRequest($"deals/{dealID}/associated_contacts", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<AssociatedContactRequest>(association));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<AssociatedContactResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(long dealID, long contactID) {
            var request = new RestRequest($"deals/{dealID}/associated_contacts/{contactID}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
