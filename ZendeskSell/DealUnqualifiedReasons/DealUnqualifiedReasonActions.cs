using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/deal_unqualified_reasons
namespace ZendeskSell.DealUnqualifiedReasons {
    public class DealUnqualifiedReasonActions : IDealUnqualifiedReasonActions {
        private RestClient _client;

        public DealUnqualifiedReasonActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DealUnqualifiedReasonResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("deal_unqualified_reasons", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<DealUnqualifiedReasonResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"deal_unqualified_reasons/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> CreateAsync(DealUnqualifiedReasonRequest reason) {
            var request = new RestRequest("deal_unqualified_reasons", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealUnqualifiedReasonRequest>(reason));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>> UpdateAsync(int id, DealUnqualifiedReasonRequest reason) {
            var request = new RestRequest($"deal_unqualified_reasons/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<DealUnqualifiedReasonRequest>(reason));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<DealUnqualifiedReasonResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"deal_unqualified_reasons/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
