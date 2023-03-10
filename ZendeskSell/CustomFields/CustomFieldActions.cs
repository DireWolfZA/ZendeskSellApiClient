using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/custom_fields
namespace ZendeskSell.CustomFields {
    public class CustomFieldActions : ICustomFieldActions {
        private RestClient _client;

        public CustomFieldActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetLeads() {
            var request = new RestRequest("lead/custom_fields", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<CustomFieldResponse>>(request, Method.GET));
        }
        public async Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetContacts() {
            var request = new RestRequest("contact/custom_fields", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<CustomFieldResponse>>(request, Method.GET));
        }
        public async Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetDeals() {
            var request = new RestRequest("deal/custom_fields", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<CustomFieldResponse>>(request, Method.GET));
        }
        public async Task<ZendeskSellCollectionResponse<CustomFieldResponse>> GetProspectAndCustomers() {
            var request = new RestRequest("prospect_and_customer/custom_fields", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<CustomFieldResponse>>(request, Method.GET));
        }
    }
}
