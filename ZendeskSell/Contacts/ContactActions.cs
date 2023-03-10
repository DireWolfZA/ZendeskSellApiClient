using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/contacts
namespace ZendeskSell.Contacts {
    public class ContactActions : IContactActions {
        private readonly RestClient _client;

        public ContactActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<ContactResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null,
                string email = null, string phone = null, string mobile = null) {
            var request = new RestRequest("contacts", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (customFields != null)
                foreach (var field in customFields)
                    request.AddParameter($"custom_fields[{field.Key}]", field.Value);
            if (email != null)
                request.AddParameter("email", email);
            if (phone != null)
                request.AddParameter("phone", phone);
            if (mobile != null)
                request.AddParameter("mobile", mobile);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<ContactResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<ContactResponse>> GetOneAsync(long id) {
            var request = new RestRequest($"contacts/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.GET));
        }

        private bool addressIsEmpty(Address address) =>
            address == null || address.Line1 == null && address.City == null && address.State == null && address.PostalCode == null && address.Country == null;

        public async Task<ZendeskSellObjectResponse<ContactResponse>> CreateAsync(ContactRequest contact) {
            Require.Argument("CustomerStatus", contact.CustomerStatus);
            Require.Argument("ProspectStatus", contact.ProspectStatus);
            Require.Argument("LastName", contact.LastName);

            if (addressIsEmpty(contact.ShippingAddress))
                contact.ShippingAddress = null;
            if (addressIsEmpty(contact.BillingAddress))
                contact.BillingAddress = null;

            var request = new RestRequest("contacts", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<ContactRequest>(contact));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<ContactResponse>> UpdateAsync(long id, ContactRequest contact) {
            Require.Argument("CustomerStatus", contact.CustomerStatus);
            Require.Argument("ProspectStatus", contact.ProspectStatus);

            if (addressIsEmpty(contact.ShippingAddress))
                contact.ShippingAddress = null;
            if (addressIsEmpty(contact.BillingAddress))
                contact.BillingAddress = null;

            var request = new RestRequest($"contacts/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<ContactRequest>(contact));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ContactResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(long id) {
            var request = new RestRequest($"contacts/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
