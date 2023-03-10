using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developer.zendesk.com/api-reference/sales-crm/resources/collaborations/
namespace ZendeskSell.Collaborations {
    public class CollaborationActions : ICollaborationActions {
        private readonly RestClient _client;

        public CollaborationActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<CollaborationResponse>> GetAsync(int pageNumber, int numPerPage, int? creatorID = null, int? resourceID = null, string resourceType = null) {
            var request = new RestRequest("collaborations", Method.GET)
                                .AddParameter("page", pageNumber)
                                .AddParameter("per_page", numPerPage);
            if (creatorID != null)
                request.AddParameter("creator_id", creatorID);
            if (resourceID != null)
                request.AddParameter("resource_id", resourceID);
            if (resourceType != null)
                request.AddParameter("resource_type", resourceType);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<CollaborationResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<CollaborationResponse>> GetOneAsync(int id) {
            var request = new RestRequest($"collaborations/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<CollaborationResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<CollaborationResponse>> CreateAsync(CollaborationRequest collaboration) {
            Require.Argument("ResourceType", collaboration.ResourceType);
            Require.Argument("ResourceID", collaboration.ResourceID == default ? (object)null : collaboration.ResourceID);
            Require.Argument("CollaboratorID", collaboration.CollaboratorID == default ? (object)null : collaboration.CollaboratorID);

            var request = new RestRequest("collaborations", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<CollaborationRequest>(collaboration));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<CollaborationResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellDeleteResponse> DeleteAsync(int id) {
            var request = new RestRequest($"collaborations/{id}", Method.DELETE);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellDeleteResponse>(request, Method.DELETE));
        }
    }
}
