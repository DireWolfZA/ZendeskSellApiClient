using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/lead_sources
namespace ZendeskSell.LeadSources {
    public class LeadSourceActions : ILeadSourceActions {
        private RestClient _client;

        public LeadSourceActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LeadSourceResponse>> GetAsync(int pageNumber, int numPerPage, string name = null) {
            var request = new RestRequest("lead_sources", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (name != null)
                request.AddParameter("name", name);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<LeadSourceResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<LeadSourceResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"lead_sources/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadSourceResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<LeadSourceResponse>> CreateAsync(LeadSourceRequest leadSource) {
            Require.Argument("ResourceType", leadSource.ResourceType);
            Require.Argument("Name", leadSource.Name);

            var request = new RestRequest("lead_sources", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadSourceRequest>(leadSource));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadSourceResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<LeadSourceResponse>> UpdateAsync(int id, LeadSourceRequest leadSource) {
            Require.Argument("ResourceType", leadSource.ResourceType);
            Require.Argument("Name", leadSource.Name);

            var request = new RestRequest($"lead_sources/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<LeadSourceRequest>(leadSource));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<LeadSourceResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"lead_sources/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
