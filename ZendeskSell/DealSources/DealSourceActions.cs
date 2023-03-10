using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/deal_sources
namespace ZendeskSell.DealSources {
    public class DealSourceActions : IDealSourceActions {
        private RestClient _client;

        public DealSourceActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DealSourceResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("deal_sources", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<DealSourceResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<DealSourceResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"deal_sources/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<DealSourceResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<DealSourceResponse>> CreateAsync(DealSourceRequest dealSource) {
            Require.Argument("ResourceType", dealSource.ResourceType);
            Require.Argument("Name", dealSource.Name);

            var request = new RestRequest("deal_sources", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealSourceRequest>(dealSource));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<DealSourceResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<DealSourceResponse>> UpdateAsync(int id, DealSourceRequest dealSource) {
            Require.Argument("ResourceType", dealSource.ResourceType);
            Require.Argument("Name", dealSource.Name);

            var request = new RestRequest($"deal_sources/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealSourceRequest>(dealSource));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<DealSourceResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"deal_sources/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
