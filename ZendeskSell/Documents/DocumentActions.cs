using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;

//https://developer.zendesk.com/api-reference/sales-crm/resources/documents/
namespace ZendeskSell.Documents {
    public class DocumentActions : IDocumentActions {
        private RestClient _client;

        public DocumentActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<DocumentResponse>> GetAsync(int pageNumber, int numPerPage, string resourceType, long resourceID, string sortBy = null, string ids = null, string name = null) {
            var request = new RestRequest("documents", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage)
                              .AddParameter("resource_type", resourceType)
                              .AddParameter("resource_id", resourceID);
            if (sortBy != null)
                request.AddParameter("sort_by", sortBy);
            if (ids != null)
                request.AddParameter("ids", ids);
            if (name != null)
                request.AddParameter("name", name);
            return (await _client.ExecuteAsync<ZendeskSellCollectionResponse<DocumentResponse>>(request, Method.GET)).Data;
        }
        public async Task<ZendeskSellObjectResponse<DocumentResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"documents/{id}", Method.GET);
            return (await _client.ExecuteAsync<ZendeskSellObjectResponse<DocumentResponse>>(request, Method.GET)).Data;
        }
    }
}
