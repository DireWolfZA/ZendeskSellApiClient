using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/loss_reasons
namespace ZendeskSell.DealLossReasons {
    public class DealLossReasonActions : IDealLossReasonActions {
        private RestClient _client;

        public DealLossReasonActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DealLossReasonResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("loss_reasons", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<DealLossReasonResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealLossReasonResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"loss_reasons/{id}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealLossReasonResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealLossReasonResponse>> CreateAsync(DealLossReasonRequest reason) {
            var request = new RestRequest("loss_reasons", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealLossReasonRequest>(reason));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealLossReasonResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealLossReasonResponse>> UpdateAsync(int id, DealLossReasonRequest reason) {
            var request = new RestRequest($"loss_reasons/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealLossReasonRequest>(reason));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DealLossReasonResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"loss_reasons/{id}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
