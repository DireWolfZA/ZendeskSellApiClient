using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/products
namespace ZendeskSell.Products {
    public class ProductActions : IProductActions {
        private RestClient _client;

        public ProductActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<ProductResponse>> GetAsync(int pageNumber, int numPerPage) {
            var request = new RestRequest("products", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<ProductResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<ProductResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"products/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ProductResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<ProductResponse>> CreateAsync(ProductRequest product) {
            Require.Argument("Name", product.Name);
            Require.Argument("Prices", product.Prices); // Prices property is initialized when class is created, so this doesn't help... (must have at least one price)

            var request = new RestRequest("products", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer(includeNullValues: false);
            request.AddJsonBody(new ZendeskSellRequest<ProductRequest>(product));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ProductResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<ProductResponse>> UpdateAsync(int id, ProductRequest product) {
            Require.Argument("Name", product.Name);
            Require.Argument("Prices", product.Prices);

            var request = new RestRequest($"products/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer(includeNullValues: false);
            request.AddJsonBody(new ZendeskSellRequest<ProductRequest>(product));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<ProductResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"products/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
