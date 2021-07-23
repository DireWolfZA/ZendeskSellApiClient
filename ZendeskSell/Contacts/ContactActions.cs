using System.Threading.Tasks;
using RestSharp;
using RestSharp.Validation;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/contacts
namespace ZendeskSell.Contacts {
    public class ContactActions : IContactActions {
        private readonly RestClient _client;

        public ContactActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<ContactResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("contacts", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<ContactResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<ContactResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"contacts/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<ContactResponse>> CreateAsync(ContactRequest contact) {
            Require.Argument("CustomerStatus", contact.CustomerStatus);
            Require.Argument("ProspectStatus", contact.ProspectStatus);
            Require.Argument("LastName", contact.LastName);

            var request = new RestRequest("contacts", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<ContactRequest>(contact));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<ContactResponse>> UpdateAsync(int id, ContactRequest contact) {
            Require.Argument("CustomerStatus", contact.CustomerStatus);
            Require.Argument("ProspectStatus", contact.ProspectStatus);

            var request = new RestRequest($"contacts/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<ContactRequest>(contact));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"contacts/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
