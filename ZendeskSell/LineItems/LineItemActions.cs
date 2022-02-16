using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/line_items
namespace ZendeskSell.LineItems {
    public class LineItemActions : ILineItemActions {
        private RestClient _client;

        public LineItemActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<LineItemResponse>> GetAsync(int orderID, int pageNumber, int numPerPage) {
            var request = new RestRequest($"orders/{orderID}/line_items", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<LineItemResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LineItemResponse>> GetOneAsync(int orderID, int lineItemID) {
            var request = new RestRequest($"orders/{orderID}/line_items/{lineItemID}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<LineItemResponse>>(request, Method.GET)).Data;
        }

        public async Task<ZendeskSellObjectResponse<LineItemResponse>> CreateAsync(int orderID, LineItemRequest lineItem) {
            Require.Argument("Currency", lineItem.Currency);
            Require.Argument("ProductID", lineItem.ProductID);

            var request = new RestRequest($"orders/{orderID}/line_items", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer(includeNullValues: false);
            request.AddJsonBody(new ZendeskSellRequest<LineItemRequest>(lineItem));
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<LineItemResponse>>(request, Method.POST)).Data;
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int orderID, int lineItemID) {
            var request = new RestRequest($"orders/{orderID}/line_items/{lineItemID}", Method.DELETE);
            return (await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE)).Data;
        }
    }
}
