using System.Threading.Tasks;
using RestSharp;
using RestSharp.Validation;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/deals
namespace ZendeskSell.Deals {
    public class DealActions : IDealActions {
        private RestClient _client;

        public DealActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DealResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("deals", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<DealResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"deals/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> CreateAsync(DealRequest deal) {
            Require.Argument("ContactID", deal.ContactID);
            Require.Argument("Hot", deal.Hot);
            Require.Argument("Name", deal.Name);
            Require.Argument("Value", deal.Value);

            var request = new RestRequest("deals", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealRequest>(deal));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> UpdateAsync(int id, DealRequest deal) {
            Require.Argument("ContactID", deal.ContactID);
            Require.Argument("StageID", deal.StageID);
            Require.Argument("OwnerID", deal.OwnerID);
            Require.Argument("Value", deal.Value);

            var request = new RestRequest($"deals/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealRequest>(deal));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"deals/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
