using System.Threading.Tasks;
using RestSharp;
using RestSharp.Validation;
using ZendeskSell.Models;

//https://developers.getbase.com/docs/rest/reference/orders
namespace ZendeskSell.Orders {
    public class OrderActions : IOrderActions {
        private RestClient _client;

        public OrderActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<OrderResponse>> GetAsync(int pageNumber, int numPerPage, int? dealID = null) {
            var request = new RestRequest("orders", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (dealID != null)
                request.AddParameter("deal_id", dealID);
            return (await _client.ExecuteTaskAsync<ZendeskSellCollectionResponse<OrderResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<OrderResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"orders/{id}", Method.GET);
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<OrderResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<OrderResponse>> CreateAsync(OrderRequest order) {
            Require.Argument("DealID", order.DealID == 0 ? (object)null : order.DealID);

            var request = new RestRequest("orders", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<OrderRequest>(order));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<OrderResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellObjectResponse<OrderResponse>> UpdateAsync(int id, OrderRequest order) {
            Require.Argument("DealID", order.DealID == 0 ? (object)null : order.DealID);

            var request = new RestRequest($"orders/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<OrderRequest>(order));
            return (await _client.ExecuteTaskAsync<ZendeskSellObjectResponse<OrderResponse>>(request, Method.PUT)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"orders/{id}", Method.DELETE);
            return (await _client.ExecuteTaskAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}