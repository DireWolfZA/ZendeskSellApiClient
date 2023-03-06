using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/deals
namespace ZendeskSell.Deals {
    public class DealActions : IDealActions {
        private RestClient _client;

        public DealActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DealResponse>> GetAsync(int pageNumber, int numPerPage, IDictionary<string, string> customFields = null,
                int? ownerID = null, int? stageID = null) {
            var request = new RestRequest("deals", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (customFields != null)
                foreach (var field in customFields)
                    request.AddParameter($"custom_fields[{field.Key}]", field.Value);
            if (ownerID != null)
                request.AddParameter("owner_id", ownerID);
            if (stageID != null)
                request.AddParameter("stage_id", stageID);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<DealResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> GetOneAsync(long id) {
            var request = new RestRequest($"deals/{id}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> CreateAsync(DealRequest deal) {
            Require.Argument("ContactID", deal.ContactID);
            Require.Argument("Hot", deal.Hot);
            Require.Argument("Name", deal.Name);
            Require.Argument("Value", deal.Value);

            var request = new RestRequest("deals", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealRequest>(deal));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealResponse>> UpdateAsync(long id, DealRequest deal) {
            Require.Argument("ContactID", deal.ContactID);
            Require.Argument("StageID", deal.StageID);
            Require.Argument("OwnerID", deal.OwnerID);
            Require.Argument("Value", deal.Value);

            var request = new RestRequest($"deals/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealRequest>(deal));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(long id) {
            var request = new RestRequest($"deals/{id}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
