using System.Threading.Tasks;
using RestSharp;
using ZendeskSell.Models;
using ZendeskSell.Utils;

//https://developers.getbase.com/docs/rest/reference/sequence_enrollments
namespace ZendeskSell.SequenceEnrollments {
    public class SequenceEnrollmentActions : ISequenceEnrollmentActions {
        private RestClient _client;

        public SequenceEnrollmentActions(RestClient client) {
            _client = client;
        }

        public async Task<ZendeskSellCollectionResponse<SequenceEnrollmentResponse>> GetAsync(int pageNumber, int numPerPage, int[] ids = null, int[] resourceIDs = null, string resourceType = null) {
            var request = new RestRequest("sequence_enrollments", Method.GET)
                              .AddParameter("page", pageNumber)
                              .AddParameter("per_page", numPerPage);
            if (ids != null)
                request.AddParameter("ids", string.Join(",", ids));
            if (resourceIDs != null)
                request.AddParameter("resource_ids", string.Join(",", resourceIDs));
            if (resourceType != null)
                request.AddParameter("resource_type", resourceType);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellCollectionResponse<SequenceEnrollmentResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<SequenceEnrollmentResponse>> GetOneAsync(long id) {
            var request = new RestRequest($"sequence_enrollments/{id}", Method.GET);
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<SequenceEnrollmentResponse>>(request, Method.GET));
        }

        public async Task<ZendeskSellObjectResponse<SequenceEnrollmentResponse>> CreateAsync(SequenceEnrollmentCreateRequest createRequest) {
            Require.Argument("ResourceType", createRequest.ResourceType);

            var request = new RestRequest("sequence_enrollments", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<SequenceEnrollmentCreateRequest>(createRequest));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<SequenceEnrollmentResponse>>(request, Method.POST));
        }

        public async Task<ZendeskSellObjectResponse<SequenceEnrollmentResponse>> UpdateAsync(long id, SequenceEnrollmentUpdateRequest updateRequest) {
            Require.Argument("State", updateRequest.State);

            var request = new RestRequest($"sequence_enrollments/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<SequenceEnrollmentUpdateRequest>(updateRequest));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<SequenceEnrollmentResponse>>(request, Method.PUT));
        }

        public async Task<ZendeskSellObjectResponse<SequenceEnrollmentFinishResponse>> FinishOngoingForResourceAsync(long id, SequenceEnrollmentFinishRequest finishRequest) {
            Require.Argument("ResourceType", finishRequest.ResourceType);

            var request = new RestRequest("sequence_enrollments/finish_ongoing_for_resource", Method.POST) { RequestFormat = DataFormat.Json };
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddJsonBody(new ZendeskSellRequest<SequenceEnrollmentFinishRequest>(finishRequest));
            return RestResponseHandler.Handle(await _client.ExecuteAsync<ZendeskSellObjectResponse<SequenceEnrollmentFinishResponse>>(request, Method.POST));
        }
    }
}
